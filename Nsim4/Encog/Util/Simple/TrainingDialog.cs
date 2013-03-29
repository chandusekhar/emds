namespace Encog.Util.Simple
{
    using Encog.ML.Train;
    using Encog.Util;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Runtime.CompilerServices;
    using System.Threading;
    using System.Windows.Forms;

    public class TrainingDialog : Form
    {
        [CompilerGenerated]
        private bool x3e4c40a0b458b605;
        private TextBox x5eeb14dd32b55d82;
        private TextBox x69348f12a2d182e0;
        [CompilerGenerated]
        private IMLTrain x70be5750812132ee;
        private Label x9001f8afc870fc4c;
        private Label x90baa23478571135;
        private IContainer xb7dfc13308b54974;
        private TextBox xdbf51c857aeb8093;
        private Button xde320a064856d64c;
        private Label xf5622c25220a6c23;

        public TrainingDialog()
        {
            this.x85601834555fb7d5();
            new Thread(new ThreadStart(this.xf2ddabe42457f139)) { IsBackground = true }.Start();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.xb7dfc13308b54974 != null))
            {
                this.xb7dfc13308b54974.Dispose();
            }
            base.Dispose(disposing);
        }

        public void PerformButtonUpdate()
        {
            this.xde320a064856d64c.Text = "Stopping";
        }

        public void PerformClose()
        {
            base.Close();
        }

        public void UpdateStats(string iterations, string error, string time)
        {
            this.xdbf51c857aeb8093.Text = iterations;
            this.x69348f12a2d182e0.Text = error;
            this.x5eeb14dd32b55d82.Text = time;
        }

        private void x328c0b730b0ebcd7(object xe0292b9ed559da7d, EventArgs xfbf34718e704c6bc)
        {
            base.BeginInvoke(new CommandDelegate(this.PerformButtonUpdate));
            this.ShouldStop = true;
        }

        private void x85601834555fb7d5()
        {
            this.xf5622c25220a6c23 = new Label();
            this.xde320a064856d64c = new Button();
            this.x9001f8afc870fc4c = new Label();
            do
            {
                this.x90baa23478571135 = new Label();
                this.x69348f12a2d182e0 = new TextBox();
                this.xdbf51c857aeb8093 = new TextBox();
                this.x5eeb14dd32b55d82 = new TextBox();
                base.SuspendLayout();
                this.xf5622c25220a6c23.AutoSize = true;
                this.xf5622c25220a6c23.Location = new Point(12, 9);
            }
            while (0 != 0);
            goto Label_03E4;
        Label_0065:
            if (0 != 0)
            {
                goto Label_00CD;
            }
            base.Controls.Add(this.x90baa23478571135);
            base.Controls.Add(this.x9001f8afc870fc4c);
            base.Controls.Add(this.xde320a064856d64c);
            if (15 != 0)
            {
                base.Controls.Add(this.xf5622c25220a6c23);
                base.Name = "TrainingDialog";
                this.Text = "Training";
                base.ResumeLayout(false);
                base.PerformLayout();
                if (0 == 0)
                {
                    return;
                }
                goto Label_0272;
            }
        Label_0096:
            base.Controls.Add(this.x69348f12a2d182e0);
            goto Label_0065;
        Label_00CD:
            base.AutoScaleMode = AutoScaleMode.Font;
        Label_00D4:
            base.ClientSize = new Size(0xfd, 0x7f);
        Label_00E6:
            base.Controls.Add(this.x5eeb14dd32b55d82);
            base.Controls.Add(this.xdbf51c857aeb8093);
            if (15 != 0)
            {
                if (0xff == 0)
                {
                    goto Label_00CD;
                }
                goto Label_0096;
            }
            goto Label_0065;
        Label_0120:
            this.x5eeb14dd32b55d82.Size = new Size(100, 20);
            if (8 != 0)
            {
                this.x5eeb14dd32b55d82.TabIndex = 6;
                base.AutoScaleDimensions = new SizeF(6f, 13f);
                goto Label_00CD;
            }
        Label_0197:
            this.xdbf51c857aeb8093.ReadOnly = true;
            this.xdbf51c857aeb8093.Size = new Size(100, 20);
            if (3 == 0)
            {
                goto Label_02A0;
            }
            this.xdbf51c857aeb8093.TabIndex = 5;
            if (0 != 0)
            {
                goto Label_0414;
            }
            this.x5eeb14dd32b55d82.Location = new Point(0x85, 0x42);
            this.x5eeb14dd32b55d82.Name = "trainingTime";
            if (0 == 0)
            {
                this.x5eeb14dd32b55d82.ReadOnly = true;
                if (4 == 0)
                {
                    goto Label_00E6;
                }
                goto Label_0120;
            }
            goto Label_0197;
        Label_0272:
            if (4 == 0)
            {
                goto Label_00D4;
            }
            this.x90baa23478571135.Name = "label3";
            this.x90baa23478571135.Size = new Size(0x4a, 13);
        Label_02A0:
            this.x90baa23478571135.TabIndex = 3;
            this.x90baa23478571135.Text = "Training Time:";
            this.x69348f12a2d182e0.Location = new Point(0x85, 6);
            this.x69348f12a2d182e0.Name = "currentError";
            if (0 == 0)
            {
                this.x69348f12a2d182e0.ReadOnly = true;
            }
            this.x69348f12a2d182e0.Size = new Size(100, 20);
            this.x69348f12a2d182e0.TabIndex = 4;
            if (0 != 0)
            {
                goto Label_02A0;
            }
            if (0 != 0)
            {
                goto Label_0120;
            }
            this.x69348f12a2d182e0.Text = "Starting...";
            this.xdbf51c857aeb8093.Location = new Point(0x85, 0x24);
            this.xdbf51c857aeb8093.Name = "iterations";
            goto Label_0197;
        Label_03E4:
            this.xf5622c25220a6c23.Name = "label1";
            this.xf5622c25220a6c23.Size = new Size(0x45, 13);
            this.xf5622c25220a6c23.TabIndex = 0;
        Label_0414:
            this.xf5622c25220a6c23.Text = "Current Error:";
            if (0 == 0)
            {
                this.xde320a064856d64c.Location = new Point(15, 0x60);
                this.xde320a064856d64c.Name = "button1";
                this.xde320a064856d64c.Size = new Size(0xda, 0x17);
                this.xde320a064856d64c.TabIndex = 1;
                if (0 != 0)
                {
                    goto Label_03E4;
                }
            }
            if (0 == 0)
            {
                do
                {
                    this.xde320a064856d64c.Text = "Stop";
                    this.xde320a064856d64c.UseVisualStyleBackColor = true;
                    this.xde320a064856d64c.Click += new EventHandler(this.x328c0b730b0ebcd7);
                    this.x9001f8afc870fc4c.AutoSize = true;
                    this.x9001f8afc870fc4c.Location = new Point(12, 0x24);
                    this.x9001f8afc870fc4c.Name = "label2";
                    this.x9001f8afc870fc4c.Size = new Size(0x35, 13);
                    this.x9001f8afc870fc4c.TabIndex = 2;
                    this.x9001f8afc870fc4c.Text = "Iterations:";
                    this.x90baa23478571135.AutoSize = true;
                    this.x90baa23478571135.Location = new Point(12, 0x42);
                }
                while (0 != 0);
            }
            goto Label_0272;
        }

        private void xf2ddabe42457f139()
        {
            int num2;
            long num4;
            object[] objArray;
            long tickCount = Environment.TickCount;
            goto Label_00DD;
        Label_0042:;
            objArray[1] = Encog.Util.Format.FormatPercent(this.Train.Error) ?? "";
            objArray[2] = Encog.Util.Format.FormatTimeSpan((int) num4) ?? "";
            if (((uint) tickCount) <= uint.MaxValue)
            {
                base.BeginInvoke(new StatsDelegate(this.UpdateStats), objArray);
                num2++;
                if (!this.ShouldStop)
                {
                    goto Label_00DF;
                }
                base.BeginInvoke(new CommandDelegate(this.PerformClose));
                if (0 == 0)
                {
                    return;
                }
                goto Label_00DD;
            }
        Label_00A5:
            objArray = new object[3];
            objArray[0] = Encog.Util.Format.FormatInteger(num2) ?? "";
            goto Label_0042;
        Label_00DD:
            num2 = 1;
        Label_00DF:
            this.Train.Iteration();
            long num3 = Environment.TickCount;
            num4 = num3 - tickCount;
            if ((((uint) tickCount) - ((uint) num4)) > uint.MaxValue)
            {
                goto Label_0042;
            }
            num4 /= 0x3e8L;
            goto Label_00A5;
        }

        public bool ShouldStop
        {
            [CompilerGenerated]
            get
            {
                return this.x3e4c40a0b458b605;
            }
            [CompilerGenerated]
            set
            {
                this.x3e4c40a0b458b605 = value;
            }
        }

        public IMLTrain Train
        {
            [CompilerGenerated]
            get
            {
                return this.x70be5750812132ee;
            }
            [CompilerGenerated]
            set
            {
                this.x70be5750812132ee = value;
            }
        }

        public delegate void CommandDelegate();

        public delegate void StatsDelegate(string iterations, string error, string time);
    }
}

