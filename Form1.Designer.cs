namespace MyWinFormsApp;

partial class Form1
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;
    PictureBox pictureBox1;
    /// <summary>
    ///  Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        this.BackColor = Color.FromArgb(179, 179, 204);
        this.FormBorderStyle = FormBorderStyle.FixedSingle;
        this.components = new System.ComponentModel.Container();
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(700, 752);
        this.Text = "Elevator";

        this.listBox1 = new System.Windows.Forms.ListBox();

        this.listBox1.FormattingEnabled = true;
        this.listBox1.Location = new System.Drawing.Point(400, 27);
        this.listBox1.Name = "listBox1";
        this.listBox1.Size = new System.Drawing.Size(300, 740);
        this.listBox1.TabIndex = 0;
        this.Controls.Add(this.listBox1);

        ToolStrip toolStrip = new ToolStrip();
        ToolStripButton stopButton = new ToolStripButton("Стоп");
        stopButton.Click += StopButton_Click;
        toolStrip.Items.Add(stopButton);

        ToolStripButton randButton = new ToolStripButton("Добавить человека");
        randButton.Click += randpeople;
        toolStrip.Items.Add(randButton);

        ToolStripButton message = new ToolStripButton("О программе");
        message.Click += ShowMessage;
        toolStrip.Items.Add(message);

        this.Controls.Add(toolStrip);

        pictureBox1 = new PictureBox();
        pictureBox1.Location = new Point(0, 0);
        pictureBox1.Size = new Size(800, 800);
        pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
        this.Controls.Add(pictureBox1);
    }

    #endregion

    public System.Windows.Forms.ListBox listBox1;
}
