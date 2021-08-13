
namespace openCV
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.mainTimer = new System.Windows.Forms.Timer(this.components);
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabTest = new System.Windows.Forms.TabPage();
            this.btnSearchTest = new System.Windows.Forms.Button();
            this.tabProd = new System.Windows.Forms.TabPage();
            this.listBox = new System.Windows.Forms.ListBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.pbMain = new System.Windows.Forms.PictureBox();
            this.pbSub = new System.Windows.Forms.PictureBox();
            this.listCopyBox = new System.Windows.Forms.ListBox();
            this.btnCopy = new System.Windows.Forms.Button();
            this.btnRun = new System.Windows.Forms.Button();
            this.btnDel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.tbTitle = new System.Windows.Forms.TextBox();
            this.tabControl.SuspendLayout();
            this.tabTest.SuspendLayout();
            this.tabProd.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSub)).BeginInit();
            this.SuspendLayout();
            // 
            // mainTimer
            // 
            this.mainTimer.Interval = 1000;
            this.mainTimer.Tick += new System.EventHandler(this.mainTimer_Tick);
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabTest);
            this.tabControl.Controls.Add(this.tabProd);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(800, 565);
            this.tabControl.TabIndex = 1;
            // 
            // tabTest
            // 
            this.tabTest.Controls.Add(this.btnSearchTest);
            this.tabTest.Location = new System.Drawing.Point(4, 22);
            this.tabTest.Name = "tabTest";
            this.tabTest.Padding = new System.Windows.Forms.Padding(3);
            this.tabTest.Size = new System.Drawing.Size(792, 539);
            this.tabTest.TabIndex = 0;
            this.tabTest.Text = "테스트";
            this.tabTest.UseVisualStyleBackColor = true;
            // 
            // btnSearchTest
            // 
            this.btnSearchTest.Location = new System.Drawing.Point(8, 6);
            this.btnSearchTest.Name = "btnSearchTest";
            this.btnSearchTest.Size = new System.Drawing.Size(115, 23);
            this.btnSearchTest.TabIndex = 1;
            this.btnSearchTest.Text = "이미지검색테스트";
            this.btnSearchTest.UseVisualStyleBackColor = true;
            this.btnSearchTest.Click += new System.EventHandler(this.btnSearchTest_Click);
            // 
            // tabProd
            // 
            this.tabProd.Controls.Add(this.tbTitle);
            this.tabProd.Controls.Add(this.btnSave);
            this.tabProd.Controls.Add(this.btnDel);
            this.tabProd.Controls.Add(this.btnRun);
            this.tabProd.Controls.Add(this.btnCopy);
            this.tabProd.Controls.Add(this.listCopyBox);
            this.tabProd.Controls.Add(this.pbSub);
            this.tabProd.Controls.Add(this.pbMain);
            this.tabProd.Controls.Add(this.btnSearch);
            this.tabProd.Controls.Add(this.listBox);
            this.tabProd.Location = new System.Drawing.Point(4, 22);
            this.tabProd.Name = "tabProd";
            this.tabProd.Padding = new System.Windows.Forms.Padding(3);
            this.tabProd.Size = new System.Drawing.Size(792, 539);
            this.tabProd.TabIndex = 1;
            this.tabProd.Text = "실행";
            this.tabProd.UseVisualStyleBackColor = true;
            // 
            // listBox
            // 
            this.listBox.FormattingEnabled = true;
            this.listBox.Location = new System.Drawing.Point(8, 6);
            this.listBox.Name = "listBox";
            this.listBox.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.listBox.Size = new System.Drawing.Size(120, 147);
            this.listBox.TabIndex = 0;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(151, 130);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 1;
            this.btnSearch.Text = "찾기";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // pbMain
            // 
            this.pbMain.Location = new System.Drawing.Point(8, 159);
            this.pbMain.Name = "pbMain";
            this.pbMain.Size = new System.Drawing.Size(218, 170);
            this.pbMain.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbMain.TabIndex = 2;
            this.pbMain.TabStop = false;
            // 
            // pbSub
            // 
            this.pbSub.Location = new System.Drawing.Point(8, 348);
            this.pbSub.Name = "pbSub";
            this.pbSub.Size = new System.Drawing.Size(218, 170);
            this.pbSub.TabIndex = 3;
            this.pbSub.TabStop = false;
            // 
            // listCopyBox
            // 
            this.listCopyBox.FormattingEnabled = true;
            this.listCopyBox.Location = new System.Drawing.Point(290, 6);
            this.listCopyBox.Name = "listCopyBox";
            this.listCopyBox.Size = new System.Drawing.Size(120, 147);
            this.listCopyBox.TabIndex = 4;
            // 
            // btnCopy
            // 
            this.btnCopy.Location = new System.Drawing.Point(151, 41);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(123, 23);
            this.btnCopy.TabIndex = 5;
            this.btnCopy.Text = "->";
            this.btnCopy.UseVisualStyleBackColor = true;
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
            // 
            // btnRun
            // 
            this.btnRun.Location = new System.Drawing.Point(439, 130);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(75, 23);
            this.btnRun.TabIndex = 6;
            this.btnRun.Text = "실행";
            this.btnRun.UseVisualStyleBackColor = true;
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
            // 
            // btnDel
            // 
            this.btnDel.Location = new System.Drawing.Point(439, 6);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(75, 23);
            this.btnDel.TabIndex = 7;
            this.btnDel.Text = "삭제";
            this.btnDel.UseVisualStyleBackColor = true;
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(638, 128);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 8;
            this.btnSave.Text = "저장";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // tbTitle
            // 
            this.tbTitle.Location = new System.Drawing.Point(532, 130);
            this.tbTitle.Name = "tbTitle";
            this.tbTitle.Size = new System.Drawing.Size(100, 20);
            this.tbTitle.TabIndex = 9;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 565);
            this.Controls.Add(this.tabControl);
            this.Name = "Form1";
            this.Text = "Form1";
            this.tabControl.ResumeLayout(false);
            this.tabTest.ResumeLayout(false);
            this.tabProd.ResumeLayout(false);
            this.tabProd.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSub)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Timer mainTimer;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabTest;
        private System.Windows.Forms.Button btnSearchTest;
        private System.Windows.Forms.TabPage tabProd;
        private System.Windows.Forms.ListBox listBox;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.PictureBox pbSub;
        private System.Windows.Forms.PictureBox pbMain;
        private System.Windows.Forms.Button btnCopy;
        private System.Windows.Forms.ListBox listCopyBox;
        private System.Windows.Forms.Button btnRun;
        private System.Windows.Forms.Button btnDel;
        private System.Windows.Forms.TextBox tbTitle;
        private System.Windows.Forms.Button btnSave;
    }
}

