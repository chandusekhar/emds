namespace Encog.ML.Data.Market.Loader
{
    using Encog.ML.Data.Market;
    using Encog.Util.CSV;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Drawing;
    using System.Linq;
    using System.Runtime.CompilerServices;
    using System.Windows.Forms;

    public class CSVFormLoader : Form
    {
        public TextBox DateTimeFormatTextBox;
        public List<MarketDataType> TypesLoaded = new List<MarketDataType>();
        private ToolStripStatusLabel x29aa5a8b6f03943c;
        [CompilerGenerated]
        private static Func<string, <>f__AnonymousType1<string>> x31af784cbc72c68d;
        private ComboBox x3994311431e22a29;
        private Label x3b9a6a473765907c;
        private TextBox x3d9c937c1f3cf311;
        private Dictionary<string, CSVFormat> x418602e78c0dace7 = new Dictionary<string, CSVFormat>();
        private StatusStrip x476fc4e9403db277;
        private CSVFormat x47e42212b0755929;
        private ListBox x583d54b8bfac1f79;
        private string x6c5f508e7be5e103 = "";
        private Label x9001f8afc870fc4c;
        private Label x90baa23478571135;
        private Dictionary<string, MarketDataType> xb58d299a5574eed1 = new Dictionary<string, MarketDataType>();
        private IContainer xb7dfc13308b54974;
        [CompilerGenerated]
        private CSVFormat xc10f63ac2c7eb361;
        private ToolTip xc4c34e75b01b4519;
        private TextBox xcbde839f0e2dff8c;
        private Label xd9083dfb11d608f7;
        private Label xdc21fb076e1552c1;
        private Button xde320a064856d64c;
        private Label xf5622c25220a6c23;
        private string[] xf62e4ef1a297d049;
        private OpenFileDialog xfb21f83c2b8edbd3;

        public CSVFormLoader()
        {
            this.x85601834555fb7d5();
            this.GetCSVFormats();
            base.ShowDialog();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.xb7dfc13308b54974 != null))
            {
                this.xb7dfc13308b54974.Dispose();
            }
            base.Dispose(disposing);
        }

        public void GetCSVFormats()
        {
            int num;
            this.x418602e78c0dace7.Add("Decimal Point", CSVFormat.DecimalPoint);
            this.x418602e78c0dace7.Add("Decimal Comma", CSVFormat.DecimalComma);
            this.x418602e78c0dace7.Add("English Format", CSVFormat.English);
            this.x418602e78c0dace7.Add("EG Format", CSVFormat.EgFormat);
            Array names = Enum.GetNames(typeof(MarketDataType));
            if ((((uint) num) - ((uint) num)) >= 0)
            {
                this.xf62e4ef1a297d049 = new string[names.Length];
                if ((((uint) num) - ((uint) num)) <= uint.MaxValue)
                {
                    num = 0;
                    IEnumerator enumerator = names.GetEnumerator();
                    try
                    {
                        while (enumerator.MoveNext())
                        {
                            this.xf62e4ef1a297d049[num] = (string) enumerator.Current;
                            num++;
                        }
                    }
                    finally
                    {
                        IDisposable disposable = enumerator as IDisposable;
                        if (0 == 0)
                        {
                            goto Label_005C;
                        }
                    Label_0053:
                        disposable.Dispose();
                        goto Label_0060;
                    Label_005C:
                        if (disposable != null)
                        {
                            goto Label_0053;
                        }
                    Label_0060:;
                    }
                }
            }
        }

        private void x03ac32bfd933b13f(object xe0292b9ed559da7d, EventArgs xfbf34718e704c6bc)
        {
            int num;
            foreach (string str in this.x418602e78c0dace7.Keys)
            {
                this.x3994311431e22a29.Items.Add(str);
            }
            string[] strArray = this.xf62e4ef1a297d049;
            if (0 == 0)
            {
                num = 0;
            }
            while (num < strArray.Length)
            {
                string item = strArray[num];
                this.x583d54b8bfac1f79.Items.Add(item);
                num++;
            }
            this.x3994311431e22a29.SelectedIndex = 2;
        }

        private void x328c0b730b0ebcd7(object xe0292b9ed559da7d, EventArgs xfbf34718e704c6bc)
        {
            this.xfb21f83c2b8edbd3 = new OpenFileDialog();
            if (4 != 0)
            {
                goto Label_012F;
            }
        Label_0015:
            this.xfb21f83c2b8edbd3.RestoreDirectory = true;
            base.Visible = false;
            do
            {
                if (this.xfb21f83c2b8edbd3.ShowDialog() != DialogResult.OK)
                {
                    return;
                }
            }
            while (0 != 0);
            string fileName = this.xfb21f83c2b8edbd3.FileName;
            try
            {
                this.Chosenfile = fileName;
                this.format = this.x418602e78c0dace7[this.x3994311431e22a29.Text];
                foreach (string str2 in this.x583d54b8bfac1f79.SelectedItems)
                {
                    this.TypesLoaded.Add((MarketDataType) Enum.Parse(typeof(MarketDataType), str2));
                }
                ReadCSV dcsv = new ReadCSV(this.Chosenfile, true, this.format);
                if (x31af784cbc72c68d == null)
                {
                    x31af784cbc72c68d = new Func<string, <>f__AnonymousType1<string>>(CSVFormLoader.xfa558b4e7f2314ad);
                }
                dcsv.ColumnNames.Select(x31af784cbc72c68d);
            }
            catch (Exception exception)
            {
                this.x29aa5a8b6f03943c.Text = "Error Loading the CSV:" + exception.Message;
            }
            return;
            if (0 == 0)
            {
                return;
            }
        Label_012F:
            this.xfb21f83c2b8edbd3.InitialDirectory = @"c:\";
            this.xfb21f83c2b8edbd3.Filter = "txt files (*.csv)|*.csv|All files (*.*)|*.*";
            this.xfb21f83c2b8edbd3.FilterIndex = 2;
            goto Label_0015;
        }

        private void x85601834555fb7d5()
        {
            this.xb7dfc13308b54974 = new Container();
            goto Label_09D3;
        Label_0010:
            this.Text = "CSVFormLoader";
            base.Load += new EventHandler(this.x03ac32bfd933b13f);
        Label_002D:
            this.x476fc4e9403db277.ResumeLayout(false);
            this.x476fc4e9403db277.PerformLayout();
            base.ResumeLayout(false);
            base.PerformLayout();
            if (0 == 0)
            {
                return;
            }
        Label_0054:
            base.ShowIcon = false;
            base.StartPosition = FormStartPosition.CenterScreen;
            goto Label_0010;
        Label_0078:
            base.Controls.Add(this.x476fc4e9403db277);
            base.MaximizeBox = false;
            base.MinimizeBox = false;
            if (2 != 0)
            {
                goto Label_071B;
            }
        Label_009E:
            base.Controls.Add(this.x3d9c937c1f3cf311);
            if (0 != 0)
            {
                goto Label_04AA;
            }
            if (15 == 0)
            {
                goto Label_01EC;
            }
            base.Controls.Add(this.xde320a064856d64c);
            goto Label_0078;
        Label_0158:
            base.Controls.Add(this.x90baa23478571135);
            if (0 != 0)
            {
                goto Label_0615;
            }
            base.Controls.Add(this.x9001f8afc870fc4c);
            if (-1 == 0)
            {
                goto Label_0078;
            }
            base.Controls.Add(this.xf5622c25220a6c23);
            base.Controls.Add(this.x3994311431e22a29);
            goto Label_009E;
        Label_01D3:
            if (15 == 0)
            {
                goto Label_033D;
            }
            if (-2 != 0)
            {
                base.Controls.Add(this.xdc21fb076e1552c1);
                base.Controls.Add(this.DateTimeFormatTextBox);
            }
            base.Controls.Add(this.xcbde839f0e2dff8c);
            base.Controls.Add(this.xd9083dfb11d608f7);
            base.Controls.Add(this.x583d54b8bfac1f79);
            base.Controls.Add(this.x3b9a6a473765907c);
            goto Label_0158;
        Label_01EC:
            this.xcbde839f0e2dff8c.Location = new Point(100, 170);
            this.xcbde839f0e2dff8c.Name = "ColumnsInCSVTextBox";
            this.xcbde839f0e2dff8c.Size = new Size(0xe5, 20);
            this.xcbde839f0e2dff8c.TabIndex = 10;
            if (0xff != 0)
            {
                base.AutoScaleDimensions = new SizeF(6f, 13f);
                base.AutoScaleMode = AutoScaleMode.Font;
                base.ClientSize = new Size(0x187, 0x1cb);
                goto Label_01D3;
            }
        Label_029C:
            this.xc4c34e75b01b4519.SetToolTip(this.xdc21fb076e1552c1, "change the datetime format");
            this.xd9083dfb11d608f7.AutoSize = true;
            if (0 != 0)
            {
                goto Label_0848;
            }
            this.xd9083dfb11d608f7.Location = new Point(4, 170);
            this.xd9083dfb11d608f7.Name = "FileColumnsLabel";
            this.xd9083dfb11d608f7.Size = new Size(0x4e, 13);
            this.xd9083dfb11d608f7.TabIndex = 9;
            this.xd9083dfb11d608f7.Text = "Columns Setup";
            if (-2147483648 == 0)
            {
                goto Label_0158;
            }
            goto Label_01EC;
        Label_033D:
            this.xdc21fb076e1552c1.AutoSize = true;
            this.xdc21fb076e1552c1.Location = new Point(7, 0xed);
            goto Label_0711;
        Label_0425:
            this.x3b9a6a473765907c.TabIndex = 7;
            this.x3b9a6a473765907c.Text = "MarketDataType";
            this.xc4c34e75b01b4519.SetToolTip(this.x3b9a6a473765907c, "Choose which data type will be loaded");
            this.x583d54b8bfac1f79.FormattingEnabled = true;
            this.x583d54b8bfac1f79.Location = new Point(100, 0x34);
            this.x583d54b8bfac1f79.Name = "MarketDataTypesListBox";
            if (0 != 0)
            {
                goto Label_0858;
            }
            this.x583d54b8bfac1f79.SelectionMode = SelectionMode.MultiExtended;
            if (0 == 0)
            {
                this.x583d54b8bfac1f79.Size = new Size(120, 0x5f);
                this.x583d54b8bfac1f79.TabIndex = 8;
                this.xc4c34e75b01b4519.SetToolTip(this.x583d54b8bfac1f79, "Market data types to use in your csv");
                this.DateTimeFormatTextBox.Location = new Point(100, 0xe7);
                this.DateTimeFormatTextBox.Name = "DateTimeFormatTextBox";
            }
            this.DateTimeFormatTextBox.Size = new Size(0xe5, 20);
            this.DateTimeFormatTextBox.TabIndex = 11;
            if (0 != 0)
            {
                goto Label_002D;
            }
            this.DateTimeFormatTextBox.Text = "yyyy.MM.dd HH:mm:ss";
            if (0x7fffffff != 0)
            {
                this.xc4c34e75b01b4519.SetToolTip(this.DateTimeFormatTextBox, "the datetime format used in the file");
                goto Label_033D;
            }
            goto Label_0711;
        Label_04AA:
            this.x90baa23478571135.Text = "Load CSV";
            this.x3b9a6a473765907c.AutoSize = true;
        Label_04C6:
            this.x3b9a6a473765907c.Location = new Point(4, 0x44);
            this.x3b9a6a473765907c.Name = "label4";
            if (15 != 0)
            {
                this.x3b9a6a473765907c.Size = new Size(0x57, 13);
            }
            goto Label_0425;
        Label_0605:
            this.xf5622c25220a6c23.Name = "label1";
        Label_0615:
            this.xf5622c25220a6c23.Size = new Size(0x3b, 13);
            if (-1 == 0)
            {
                goto Label_088C;
            }
            this.xf5622c25220a6c23.TabIndex = 4;
            this.xf5622c25220a6c23.Text = "Loaded file";
            this.x9001f8afc870fc4c.AutoSize = true;
            this.x9001f8afc870fc4c.Location = new Point(4, 14);
            this.x9001f8afc870fc4c.Name = "label2";
            this.x9001f8afc870fc4c.Size = new Size(0x3f, 13);
            if (-1 == 0)
            {
                goto Label_07EB;
            }
            if (0 != 0)
            {
                goto Label_04C6;
            }
            this.x9001f8afc870fc4c.TabIndex = 5;
            this.x9001f8afc870fc4c.Text = "CSV Format";
            if (2 == 0)
            {
                goto Label_01D3;
            }
            if (2 == 0)
            {
                goto Label_07EB;
            }
            this.x90baa23478571135.AutoSize = true;
            this.x90baa23478571135.Location = new Point(4, 0x167);
            this.x90baa23478571135.Name = "label3";
            if (-2 == 0)
            {
                goto Label_0946;
            }
            if (3 == 0)
            {
                goto Label_0010;
            }
            this.x90baa23478571135.Size = new Size(0x37, 13);
            if (-1 == 0)
            {
                goto Label_07DB;
            }
            this.x90baa23478571135.TabIndex = 6;
            goto Label_04AA;
        Label_0711:
            if (0x7fffffff != 0)
            {
                this.xdc21fb076e1552c1.Name = "label5";
                this.xdc21fb076e1552c1.Size = new Size(0x55, 13);
                this.xdc21fb076e1552c1.TabIndex = 12;
                this.xdc21fb076e1552c1.Text = "DateTime format";
                goto Label_029C;
            }
        Label_071B:
            if (0 == 0)
            {
                base.Name = "CSVFormLoader";
                goto Label_0054;
            }
            goto Label_09D3;
        Label_07DB:
            this.xde320a064856d64c.Name = "button1";
        Label_07EB:
            this.xde320a064856d64c.Size = new Size(0x79, 0x25);
            this.xde320a064856d64c.TabIndex = 1;
            this.xde320a064856d64c.Text = "Load CSV";
            this.xc4c34e75b01b4519.SetToolTip(this.xde320a064856d64c, "Load your CSV");
            this.xde320a064856d64c.UseVisualStyleBackColor = true;
            this.xde320a064856d64c.Click += new EventHandler(this.x328c0b730b0ebcd7);
            this.x3d9c937c1f3cf311.Location = new Point(0x42, 0x193);
            if (0 == 0)
            {
                this.x3d9c937c1f3cf311.Name = "textBox1";
                this.x3d9c937c1f3cf311.ReadOnly = true;
                this.x3d9c937c1f3cf311.Size = new Size(0x10b, 20);
                this.x3d9c937c1f3cf311.TabIndex = 2;
                if ((0 == 0) && (4 == 0))
                {
                    goto Label_0425;
                }
                while (true)
                {
                    this.xc4c34e75b01b4519.SetToolTip(this.x3d9c937c1f3cf311, "Path to your file");
                    this.x3994311431e22a29.FormattingEnabled = true;
                    this.x3994311431e22a29.Location = new Point(100, 6);
                    this.x3994311431e22a29.Name = "CSVFormatsCombo";
                    this.x3994311431e22a29.Size = new Size(0x79, 0x15);
                    this.x3994311431e22a29.TabIndex = 3;
                    this.xc4c34e75b01b4519.SetToolTip(this.x3994311431e22a29, "CSVFormat to use");
                    this.xf5622c25220a6c23.AutoSize = true;
                    this.xf5622c25220a6c23.Location = new Point(4, 410);
                    if (8 != 0)
                    {
                        goto Label_0605;
                    }
                }
            }
        Label_0813:
            this.xde320a064856d64c.Location = new Point(100, 0x14f);
            goto Label_07DB;
        Label_0848:
            this.x476fc4e9403db277.Text = "statusStrip1";
        Label_0858:
            this.x29aa5a8b6f03943c.Name = "toolStripStatusLabel1";
            this.x29aa5a8b6f03943c.Size = new Size(0x2c, 0x11);
            this.x29aa5a8b6f03943c.Text = "Nothing";
        Label_088C:
            this.xde320a064856d64c.DialogResult = DialogResult.Yes;
            goto Label_0813;
        Label_08E9:
            this.xcbde839f0e2dff8c = new TextBox();
            this.x476fc4e9403db277.SuspendLayout();
            base.SuspendLayout();
            this.x476fc4e9403db277.Items.AddRange(new ToolStripItem[] { this.x29aa5a8b6f03943c });
            this.x476fc4e9403db277.Location = new Point(0, 0x1b5);
            this.x476fc4e9403db277.Name = "statusStrip1";
            this.x476fc4e9403db277.Size = new Size(0x187, 0x16);
            if (4 != 0)
            {
                this.x476fc4e9403db277.TabIndex = 0;
                goto Label_0848;
            }
        Label_093B:
            this.x583d54b8bfac1f79 = new ListBox();
        Label_0946:
            this.DateTimeFormatTextBox = new TextBox();
            this.xdc21fb076e1552c1 = new Label();
            if (1 == 0)
            {
                goto Label_0605;
            }
            this.xd9083dfb11d608f7 = new Label();
            if (0 == 0)
            {
                goto Label_08E9;
            }
        Label_0974:
            this.xf5622c25220a6c23 = new Label();
            this.x9001f8afc870fc4c = new Label();
            this.x90baa23478571135 = new Label();
            if (2 == 0)
            {
                return;
            }
            this.xc4c34e75b01b4519 = new ToolTip(this.xb7dfc13308b54974);
            if (15 != 0)
            {
                this.x3b9a6a473765907c = new Label();
                goto Label_093B;
            }
            goto Label_08E9;
        Label_09D3:
            this.x476fc4e9403db277 = new StatusStrip();
            this.x29aa5a8b6f03943c = new ToolStripStatusLabel();
            this.xde320a064856d64c = new Button();
            if (0xff != 0)
            {
                this.x3d9c937c1f3cf311 = new TextBox();
                this.x3994311431e22a29 = new ComboBox();
                goto Label_0974;
            }
            goto Label_08E9;
        }

        private void xe6ce85794560f647(object xe0292b9ed559da7d, EventArgs xfbf34718e704c6bc)
        {
            this.Chosenfile = this.xfb21f83c2b8edbd3.FileName;
            this.x29aa5a8b6f03943c.Text = " File:" + this.xfb21f83c2b8edbd3.FileName + " has been successfully loaded";
        }

        [CompilerGenerated]
        private static <>f__AnonymousType1<string> xfa558b4e7f2314ad(string x33994cad95b6c865)
        {
            return new { Names = x33994cad95b6c865 };
        }

        public string Chosenfile
        {
            get
            {
                return this.x6c5f508e7be5e103;
            }
            set
            {
                this.x6c5f508e7be5e103 = value;
            }
        }

        public CSVFormat CurrentFormat
        {
            get
            {
                return this.x47e42212b0755929;
            }
            set
            {
                this.x47e42212b0755929 = value;
            }
        }

        public CSVFormat format
        {
            [CompilerGenerated]
            get
            {
                return this.xc10f63ac2c7eb361;
            }
            [CompilerGenerated]
            set
            {
                this.xc10f63ac2c7eb361 = value;
            }
        }

        public List<MarketDataType> MarketTypesUsed
        {
            get
            {
                return this.TypesLoaded;
            }
            set
            {
                this.TypesLoaded = value;
            }
        }
    }
}

