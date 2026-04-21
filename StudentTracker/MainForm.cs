using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace StudentTracker
{
    public partial class MainForm : Form
    {
        private readonly IRepository<TaskItem> _taskRepository;
        private DataGridView dgvTasks;
        private int _nextId = 3;

        public MainForm()
        {
            InitializeComponent();
            _taskRepository = new TaskRepository();
     
            DrawInterface();
            RefreshGrid();
        }

        private void DrawInterface()
        {
            this.Text = "Студентський Task Tracker";
            this.Size = new Size(900, 500);
            this.StartPosition = FormStartPosition.CenterScreen;

            Button btnAddTask = new Button() { Text = "Додати завдання", Location = new Point(10, 10), Size = new Size(130, 30), BackColor = Color.LightGreen, Font = new Font(this.Font, FontStyle.Bold) };
            btnAddTask.Click += BtnAddTask_Click;

            dgvTasks = new DataGridView();
            dgvTasks.Location = new Point(10, 50);
            dgvTasks.Size = new Size(860, 390);
            dgvTasks.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvTasks.AllowUserToAddRows = false;
            dgvTasks.RowHeadersVisible = false;
            dgvTasks.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

          
            dgvTasks.Columns.Add("Id", "ID");
            dgvTasks.Columns["Id"].Visible = false; 
            dgvTasks.Columns.Add("Title", "Назва завдання");
            dgvTasks.Columns.Add("Deadline", "Дедлайн");
            dgvTasks.Columns.Add("Status", "Статус");

           
            DataGridViewButtonColumn btnEdit = new DataGridViewButtonColumn() { HeaderText = "Редагувати", Text = "📝", UseColumnTextForButtonValue = true, Width = 80 };
            DataGridViewButtonColumn btnStatus = new DataGridViewButtonColumn() { HeaderText = "Статус", Text = "Готово ✓", UseColumnTextForButtonValue = true, Width = 80 };
            DataGridViewButtonColumn btnDelete = new DataGridViewButtonColumn() { HeaderText = "Видалити", Text = "❌", UseColumnTextForButtonValue = true, Width = 80 };

            dgvTasks.Columns.AddRange(new DataGridViewColumn[] { btnEdit, btnStatus, btnDelete });

         
            dgvTasks.CellContentClick += DgvTasks_CellContentClick;

            this.Controls.AddRange(new Control[] { btnAddTask, dgvTasks });
        }

        private void RefreshGrid()
        {
            dgvTasks.Rows.Clear();
            foreach (var task in _taskRepository.GetAll())
            {
                string statusText = task.Status == TaskStatus.Completed ? "Виконано" :
                                    task.Status == TaskStatus.InProgress ? "В процесі" : "На черзі";
                dgvTasks.Rows.Add(task.Id, task.Title, task.DueDate.ToString("dd.MM.yyyy"), statusText);
            }
        }

       
        private void BtnAddTask_Click(object sender, EventArgs e)
        {
            using (TaskForm form = new TaskForm(_nextId++, 1)) 
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    _taskRepository.Add(form.ResultTask);
                    RefreshGrid();
                }
            }
        }

       
        private void DgvTasks_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            int taskId = (int)dgvTasks.Rows[e.RowIndex].Cells["Id"].Value;
            var task = _taskRepository.GetById(taskId);

            if (task == null) return;

            
            if (e.ColumnIndex == 4)
            {
                using (TaskForm form = new TaskForm(task))
                {
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        _taskRepository.Remove(task); 
                        _taskRepository.Add(form.ResultTask);
                        RefreshGrid();
                    }
                }
            }
            
            else if (e.ColumnIndex == 5)
            {
                task.MarkAsDone();
                RefreshGrid();
            }
           
            else if (e.ColumnIndex == 6)
            {
                if (MessageBox.Show("Точно видалити?", "Підтвердження", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    _taskRepository.Remove(task);
                    RefreshGrid();
                }
            }
        }
    }
}