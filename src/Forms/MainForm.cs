namespace ClassWork_24_02_2024_Dynamic.Forms;

public partial class MainForm : Form
{
    private int _nextY = 30;

    private FileInfo[]? _files;

    DirectoryInfo? _directory;

    public MainForm()
    {
        InitializeComponent();
    }

    private void MainFormLoad(object sender, EventArgs e)
    {
        _directory = new DirectoryInfo(".");

        _files = _directory.GetFiles();

        RenderFiles();
    }


    private void RenderFiles()
    {
        for (int i = 0; i < _files.Length; i++)
        {
            RenderFile(i);
        }
    }

    private void RenderFile(int fileIndex)
    {
        var file = _files[fileIndex];

        var textBox = new TextBox();
        textBox.Width = 260;
        textBox.Text = file.Name;
        textBox.Tag = fileIndex;
        textBox.Location = new Point(10, _nextY);
        Controls.Add(textBox);

        var buttonUpdate = new Button();
        buttonUpdate.Click += UpdateButtonClick;
        buttonUpdate.Location = new Point(280, _nextY);
        buttonUpdate.Width = 80;
        buttonUpdate.Text = "Update file";
        buttonUpdate.Tag = fileIndex;
        Controls.Add(buttonUpdate);

        var buttonDelete = new Button();
        buttonDelete.Click += DeleteButtonClick;
        buttonDelete.Location = new Point(370, _nextY);
        buttonDelete.Width = 80;
        buttonDelete.Text = "Delete file";
        buttonDelete.Tag = fileIndex;
        Controls.Add(buttonDelete);

        _nextY += 25;
    }


    private void DeleteButtonClick(object sender, EventArgs e)
    {
        var button = sender as Button;

        int fileIndex = (int)button.Tag;

        File.Delete(_files[fileIndex].Name);

        _files = _files
            .Where((_, index) => index != fileIndex)
            .ToArray();

        RemoveFiles(fileIndex);

        RefreshPosition(fileIndex);
    }


    private void RemoveFiles(int fileIndex)
    {
        for(int i = Controls.Count - 1; i >= 0; i--)
        {
            Control control = Controls[i];

            if (control is TextBox textBox && (int)textBox.Tag == fileIndex)
            {
                Controls.RemoveAt(i);

                break;
            }

            if (control is Button updateButton && ((int)updateButton.Tag == fileIndex && updateButton.Text == "Update file"))
            {
                Controls.RemoveAt(i);
            }

            if (control is Button deleteButton && ((int)deleteButton.Tag == fileIndex && deleteButton.Text == "Delete file"))
            {
                Controls.RemoveAt(i);
            }
        }
    }

    private void RefreshPosition(int deletedFileIndex)
    {
        foreach (Control control in Controls)
        {
            if (control is TextBox || control is Button)
            {
                if ((int)control.Tag > deletedFileIndex)
                {
                    control.Location = new Point(control.Location.X, control.Location.Y - 25);

                    control.Tag = (int)control.Tag - 1;
                }
            }
        }
    }

    private void UpdateButtonClick(object? sender, EventArgs e)
    {
        var button = sender as Button;

        var fileIndex = (int)button.Tag;

        foreach (var control in Controls)
        {
            if (control is TextBox textBox)
            {
                if ((int)textBox.Tag == fileIndex)
                {
                    var text = textBox.Text;

                    string? oldName = _files[fileIndex].FullName;

                    string? newName = Path.Combine(_directory.FullName, textBox.Text);

                    File.Move(oldName, newName);

                    _files[fileIndex] = new FileInfo(newName);

                    MessageBox.Show("Successfully updated!");

                }
            }
        }
    }
}