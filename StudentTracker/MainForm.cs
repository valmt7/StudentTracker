using System;
using System.Drawing;
using System.Windows.Forms;

namespace StudentTracker
{

    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            DrawInterface(); 
        }

        private void DrawInterface()
        {
          
            this.Text = "Студентський Task Tracker";
            this.Size = new Size(820, 500);
            this.StartPosition = FormStartPosition.CenterScreen;

           //кнопки керування
            Button btnAuth = new Button() { Text = "Авторизація", Location = new Point(10, 10), Size = new Size(100, 30) };
            Button btnAddSubject = new Button() { Text = "Додати дисципліну", Location = new Point(120, 10), Size = new Size(130, 30) };

            Button btnAddTask = new Button() { Text = "Додати завдання", Location = new Point(260, 10), Size = new Size(130, 30), BackColor = Color.LightGreen, Font = new Font(this.Font, FontStyle.Bold) };

            // логіка кнопки
            btnAddTask.Click += btnAddTask_Click;

            //сортування + фільтри
            Label lblFilter = new Label() { Text = "Фільтр за статусом:", Location = new Point(10, 55), AutoSize = true };
            ComboBox cmbFilter = new ComboBox() { Location = new Point(130, 50), Size = new Size(120, 25), DropDownStyle = ComboBoxStyle.DropDownList };
            cmbFilter.Items.AddRange(new string[] { "Всі", "На черзі", "В процесі", "Виконано" });
            cmbFilter.SelectedIndex = 0;

            Label lblSort = new Label() { Text = "Сортування:", Location = new Point(270, 55), AutoSize = true };
            ComboBox cmbSort = new ComboBox() { Location = new Point(350, 50), Size = new Size(130, 25), DropDownStyle = ComboBoxStyle.DropDownList };
            cmbSort.Items.AddRange(new string[] { "За датою здачі", "За статусом" });
            cmbSort.SelectedIndex = 0;

            // табличка
            DataGridView dgvTasks = new DataGridView();
            dgvTasks.Location = new Point(10, 90);
            dgvTasks.Size = new Size(780, 350);
            dgvTasks.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvTasks.AllowUserToAddRows = false;
            dgvTasks.RowHeadersVisible = false;
            dgvTasks.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dgvTasks.Columns.Add("Subject", "Предмет");
            dgvTasks.Columns.Add("Title", "Назва завдання");
            dgvTasks.Columns.Add("Deadline", "Дедлайн");
            dgvTasks.Columns.Add("Status", "Статус");

            DataGridViewButtonColumn btnStatus = new DataGridViewButtonColumn();
            btnStatus.HeaderText = "Дія";
            btnStatus.Text = "Готово ✓";
            btnStatus.UseColumnTextForButtonValue = true;
            dgvTasks.Columns.Add(btnStatus);

            DataGridViewButtonColumn btnDelete = new DataGridViewButtonColumn();
            btnDelete.HeaderText = "Видалення";
            btnDelete.Text = "❌";
            btnDelete.UseColumnTextForButtonValue = true;
            dgvTasks.Columns.Add(btnDelete);

            // тести
            dgvTasks.Rows.Add("Програмування", "Практична 1", "22.04.2026 23:59", "На черзі");
            dgvTasks.Rows.Add("Дискретна математика", "РГР", "25.04.2026 12:00", "В процесі");

            // ініт
            this.Controls.Add(btnAuth);
            this.Controls.Add(btnAddSubject);
            this.Controls.Add(btnAddTask);
            this.Controls.Add(lblFilter);
            this.Controls.Add(cmbFilter);
            this.Controls.Add(lblSort);
            this.Controls.Add(cmbSort);
            this.Controls.Add(dgvTasks);
        }

        // методи(поки заглушка)
        private void btnAddTask_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Додавання задачі (поки заглушка)");
        }

        private void btnDeleteTask_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Видалення задачі (поки заглушка)");
        }

        private void btnEditTask_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Редагування задачі (поки заглушка)");
        }
    }
}