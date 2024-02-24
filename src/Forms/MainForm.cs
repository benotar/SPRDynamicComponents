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
        textBox.Width = 230;
        textBox.Text = file.Name;
        textBox.Tag = fileIndex;
        textBox.Location = new Point(12, _nextY);
        Controls.Add(textBox);

        var button = new Button();
        button.Click += UpdateButtonClick;
        button.Location = new Point(260, _nextY);
        button.Text = "Update";
        button.Tag = fileIndex;
        Controls.Add(button);

        _nextY += 25;
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

                    MessageBox.Show(_files[fileIndex].Name);
                }
            }
        }
    }
}