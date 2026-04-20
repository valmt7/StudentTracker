using System;
using System.Drawing;
using System.Windows.Forms;

namespace StudentTracker
{
    public partial class TaskForm : Form
    {
        private TextBox txtTitle;
        private TextBox txtDescription;
        private DateTimePicker dtpDueDate;
        private ComboBox cmbStatus;
        private Button btnSave;

       
        public TaskItem ResultTask { get; private set; }
        private int _taskId;
        private int _subjectId;

      
        public TaskForm(int newTaskId, int subjectId)
        {
            _taskId = newTaskId;
            _subjectId = subjectId;
            InitUI();
            this.Text = "Додати завдання";
        }

       
        public TaskForm(TaskItem existingTask)
        {
            _taskId = existingTask.Id;
            _subjectId = existingTask.SubjectId;
            InitUI();
            this.Text = "Редагувати завдання";

            
            txtTitle.Text = existingTask.Title;
            txtDescription.Text = existingTask.Description;
            dtpDueDate.Value = existingTask.DueDate;
            cmbStatus.SelectedIndex = (int)existingTask.Status;
        }

        private void InitUI()
        {
            this.Size = new Size(350, 300);
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;

            Label lblTitle = new Label() { Text = "Назва:", Location = new Point(10, 15), AutoSize = true };
            txtTitle = new TextBox() { Location = new Point(100, 10), Width = 200 };

            Label lblDesc = new Label() { Text = "Опис:", Location = new Point(10, 50), AutoSize = true };
            txtDescription = new TextBox() { Location = new Point(100, 45), Width = 200, Height = 60, Multiline = true };

            Label lblDate = new Label() { Text = "Дедлайн:", Location = new Point(10, 120), AutoSize = true };
            dtpDueDate = new DateTimePicker() { Location = new Point(100, 115), Width = 200, Format = DateTimePickerFormat.Short };

            Label lblStatus = new Label() { Text = "Статус:", Location = new Point(10, 160), AutoSize = true };
            cmbStatus = new ComboBox() { Location = new Point(100, 155), Width = 200, DropDownStyle = ComboBoxStyle.DropDownList };
            cmbStatus.Items.AddRange(new string[] { "На черзі", "В процесі", "Виконано" });
            cmbStatus.SelectedIndex = 0;

            btnSave = new Button() { Text = "Зберегти", Location = new Point(100, 200), Width = 100, BackColor = Color.LightGreen };
            btnSave.Click += BtnSave_Click;

            this.Controls.AddRange(new Control[] { lblTitle, txtTitle, lblDesc, txtDescription, lblDate, dtpDueDate, lblStatus, cmbStatus, btnSave });
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTitle.Text))
            {
                MessageBox.Show("Введіть назву завдання!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            
            ResultTask = new TaskItem(_taskId, _subjectId, txtTitle.Text, txtDescription.Text, dtpDueDate.Value);
            ResultTask.ChangeStatus((TaskStatus)cmbStatus.SelectedIndex);

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}