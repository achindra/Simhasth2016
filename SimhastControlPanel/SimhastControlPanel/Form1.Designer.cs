namespace SimhastControlPanel
{
    partial class frmApp
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.lblRadius = new System.Windows.Forms.Label();
            this.lblSearch = new System.Windows.Forms.Label();
            this.txtMessage = new System.Windows.Forms.TextBox();
            this.lblMsgLength = new System.Windows.Forms.Label();
            this.gMapControl = new GMap.NET.WindowsForms.GMapControl();
            this.btnSend = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.lstMapType = new System.Windows.Forms.ListBox();
            this.lblMap = new System.Windows.Forms.Label();
            this.radioButton4 = new System.Windows.Forms.RadioButton();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.trackBarZoom = new System.Windows.Forms.TrackBar();
            this.lblZoom = new System.Windows.Forms.Label();
            this.txtSid = new System.Windows.Forms.TextBox();
            this.txtToken = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNumber = new System.Windows.Forms.TextBox();
            this.lstMsgResponse = new System.Windows.Forms.ListBox();
            this.txtAuthKey = new System.Windows.Forms.TextBox();
            this.txtSenderId = new System.Windows.Forms.TextBox();
            this.txtWebResponse = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarZoom)).BeginInit();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.statusStrip1.Location = new System.Drawing.Point(0, 1122);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1570, 22);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Location = new System.Drawing.Point(26, 78);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(51, 24);
            this.radioButton1.TabIndex = 1;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "All";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // trackBar1
            // 
            this.trackBar1.LargeChange = 500;
            this.trackBar1.Location = new System.Drawing.Point(26, 169);
            this.trackBar1.Maximum = 15000;
            this.trackBar1.Minimum = 500;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(438, 69);
            this.trackBar1.SmallChange = 500;
            this.trackBar1.TabIndex = 0;
            this.trackBar1.TickFrequency = 500;
            this.trackBar1.Value = 710;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            this.trackBar1.ValueChanged += new System.EventHandler(this.trackBar1_ValueChanged);
            // 
            // lblRadius
            // 
            this.lblRadius.AutoSize = true;
            this.lblRadius.Location = new System.Drawing.Point(22, 134);
            this.lblRadius.Name = "lblRadius";
            this.lblRadius.Size = new System.Drawing.Size(107, 20);
            this.lblRadius.TabIndex = 501;
            this.lblRadius.Text = "Radius: 500m";
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.Location = new System.Drawing.Point(22, 49);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(87, 20);
            this.lblSearch.TabIndex = 502;
            this.lblSearch.Text = "Search for:";
            // 
            // txtMessage
            // 
            this.txtMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMessage.Location = new System.Drawing.Point(1111, 57);
            this.txtMessage.Multiline = true;
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.Size = new System.Drawing.Size(446, 254);
            this.txtMessage.TabIndex = 503;
            this.txtMessage.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtMessage_KeyUp);
            // 
            // lblMsgLength
            // 
            this.lblMsgLength.AutoSize = true;
            this.lblMsgLength.Location = new System.Drawing.Point(1118, 338);
            this.lblMsgLength.Name = "lblMsgLength";
            this.lblMsgLength.Size = new System.Drawing.Size(49, 20);
            this.lblMsgLength.TabIndex = 504;
            this.lblMsgLength.Text = "0/160";
            // 
            // gMapControl
            // 
            this.gMapControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gMapControl.Bearing = 0F;
            this.gMapControl.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.gMapControl.CanDragMap = true;
            this.gMapControl.EmptyTileColor = System.Drawing.Color.Navy;
            this.gMapControl.GrayScaleMode = false;
            this.gMapControl.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow;
            this.gMapControl.LevelsKeepInMemmory = 5;
            this.gMapControl.Location = new System.Drawing.Point(12, 378);
            this.gMapControl.MarkersEnabled = true;
            this.gMapControl.MaxZoom = 17;
            this.gMapControl.MinZoom = 5;
            this.gMapControl.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter;
            this.gMapControl.Name = "gMapControl";
            this.gMapControl.NegativeMode = false;
            this.gMapControl.PolygonsEnabled = true;
            this.gMapControl.RetryLoadTile = 0;
            this.gMapControl.RoutesEnabled = true;
            this.gMapControl.ScaleMode = GMap.NET.WindowsForms.ScaleModes.Integer;
            this.gMapControl.SelectedAreaFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(65)))), ((int)(((byte)(105)))), ((int)(((byte)(225)))));
            this.gMapControl.ShowTileGridLines = false;
            this.gMapControl.Size = new System.Drawing.Size(1537, 741);
            this.gMapControl.TabIndex = 505;
            this.gMapControl.Zoom = 14D;
            this.gMapControl.OnMapDrag += new GMap.NET.MapDrag(this.gMapControl_OnMapDrag);
            this.gMapControl.DoubleClick += new System.EventHandler(this.gMapControl_DoubleClick);
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(1433, 330);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(125, 36);
            this.btnSend.TabIndex = 506;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(1279, 331);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(125, 36);
            this.btnClear.TabIndex = 507;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // lstMapType
            // 
            this.lstMapType.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstMapType.FormattingEnabled = true;
            this.lstMapType.ItemHeight = 29;
            this.lstMapType.Items.AddRange(new object[] {
            "Bing",
            "Google",
            "OpenStreet",
            "Wikimapia",
            "Yahoo",
            "Cloud",
            "Near",
            "OpenCycle",
            "Ovi"});
            this.lstMapType.Location = new System.Drawing.Point(526, 78);
            this.lstMapType.Name = "lstMapType";
            this.lstMapType.Size = new System.Drawing.Size(178, 265);
            this.lstMapType.TabIndex = 508;
            this.lstMapType.SelectedIndexChanged += new System.EventHandler(this.lstMapType_SelectedIndexChanged);
            // 
            // lblMap
            // 
            this.lblMap.AutoSize = true;
            this.lblMap.Location = new System.Drawing.Point(488, 49);
            this.lblMap.Name = "lblMap";
            this.lblMap.Size = new System.Drawing.Size(77, 20);
            this.lblMap.TabIndex = 509;
            this.lblMap.Text = "Pick Map:";
            // 
            // radioButton4
            // 
            this.radioButton4.AutoSize = true;
            this.radioButton4.Location = new System.Drawing.Point(361, 78);
            this.radioButton4.Name = "radioButton4";
            this.radioButton4.Size = new System.Drawing.Size(103, 24);
            this.radioButton4.TabIndex = 4;
            this.radioButton4.Tag = "Volunteer";
            this.radioButton4.Text = "Volunteer";
            this.radioButton4.UseVisualStyleBackColor = true;
            this.radioButton4.CheckedChanged += new System.EventHandler(this.radioButton4_CheckedChanged);
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Location = new System.Drawing.Point(243, 78);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(76, 24);
            this.radioButton3.TabIndex = 3;
            this.radioButton3.Tag = "Staff";
            this.radioButton3.Text = "Medic";
            this.radioButton3.UseVisualStyleBackColor = true;
            this.radioButton3.CheckedChanged += new System.EventHandler(this.radioButton3_CheckedChanged);
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(119, 78);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(82, 24);
            this.radioButton2.TabIndex = 2;
            this.radioButton2.Tag = "Doctor";
            this.radioButton2.Text = "Doctor";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // trackBarZoom
            // 
            this.trackBarZoom.LargeChange = 2;
            this.trackBarZoom.Location = new System.Drawing.Point(26, 273);
            this.trackBarZoom.Maximum = 18;
            this.trackBarZoom.Name = "trackBarZoom";
            this.trackBarZoom.Size = new System.Drawing.Size(438, 69);
            this.trackBarZoom.TabIndex = 510;
            this.trackBarZoom.TickStyle = System.Windows.Forms.TickStyle.TopLeft;
            this.trackBarZoom.Value = 14;
            this.trackBarZoom.Scroll += new System.EventHandler(this.trackBarZoom_Scroll);
            this.trackBarZoom.ValueChanged += new System.EventHandler(this.trackBarZoom_ValueChanged);
            // 
            // lblZoom
            // 
            this.lblZoom.AutoSize = true;
            this.lblZoom.Location = new System.Drawing.Point(26, 247);
            this.lblZoom.Name = "lblZoom";
            this.lblZoom.Size = new System.Drawing.Size(76, 20);
            this.lblZoom.TabIndex = 511;
            this.lblZoom.Text = "Zoom: 14";
            // 
            // txtSid
            // 
            this.txtSid.Location = new System.Drawing.Point(761, 86);
            this.txtSid.Name = "txtSid";
            this.txtSid.Size = new System.Drawing.Size(330, 26);
            this.txtSid.TabIndex = 512;
            this.txtSid.Text = "AC3192136300df3ea9c44b626c03d37ee5";
            // 
            // txtToken
            // 
            this.txtToken.Location = new System.Drawing.Point(761, 177);
            this.txtToken.Name = "txtToken";
            this.txtToken.Size = new System.Drawing.Size(330, 26);
            this.txtToken.TabIndex = 513;
            this.txtToken.Text = "3cbfd68ab0ad16317ec89d6e759b3b3a";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(757, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 20);
            this.label1.TabIndex = 514;
            this.label1.Text = "Account SID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(757, 154);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(116, 20);
            this.label2.TabIndex = 515;
            this.label2.Text = "Account Token";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(757, 262);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(106, 20);
            this.label3.TabIndex = 516;
            this.label3.Text = "From Number";
            // 
            // txtNumber
            // 
            this.txtNumber.Location = new System.Drawing.Point(761, 285);
            this.txtNumber.Name = "txtNumber";
            this.txtNumber.Size = new System.Drawing.Size(330, 26);
            this.txtNumber.TabIndex = 517;
            this.txtNumber.Text = "+12023350630";
            // 
            // lstMsgResponse
            // 
            this.lstMsgResponse.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstMsgResponse.FormattingEnabled = true;
            this.lstMsgResponse.ItemHeight = 20;
            this.lstMsgResponse.Location = new System.Drawing.Point(1618, 57);
            this.lstMsgResponse.Name = "lstMsgResponse";
            this.lstMsgResponse.Size = new System.Drawing.Size(0, 304);
            this.lstMsgResponse.TabIndex = 518;
            // 
            // txtAuthKey
            // 
            this.txtAuthKey.Location = new System.Drawing.Point(761, 119);
            this.txtAuthKey.Name = "txtAuthKey";
            this.txtAuthKey.Size = new System.Drawing.Size(330, 26);
            this.txtAuthKey.TabIndex = 519;
            this.txtAuthKey.Text = "11899AtSpCv19U57065684";
            // 
            // txtSenderId
            // 
            this.txtSenderId.Location = new System.Drawing.Point(761, 210);
            this.txtSenderId.Name = "txtSenderId";
            this.txtSenderId.Size = new System.Drawing.Size(330, 26);
            this.txtSenderId.TabIndex = 520;
            this.txtSenderId.Text = "9731722511";
            // 
            // txtWebResponse
            // 
            this.txtWebResponse.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtWebResponse.Location = new System.Drawing.Point(2158, 60);
            this.txtWebResponse.Multiline = true;
            this.txtWebResponse.Name = "txtWebResponse";
            this.txtWebResponse.Size = new System.Drawing.Size(0, 301);
            this.txtWebResponse.TabIndex = 521;
            // 
            // frmApp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1570, 1144);
            this.Controls.Add(this.txtWebResponse);
            this.Controls.Add(this.txtSenderId);
            this.Controls.Add(this.txtAuthKey);
            this.Controls.Add(this.lstMsgResponse);
            this.Controls.Add(this.txtNumber);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtToken);
            this.Controls.Add(this.txtSid);
            this.Controls.Add(this.lblZoom);
            this.Controls.Add(this.trackBarZoom);
            this.Controls.Add(this.lblMap);
            this.Controls.Add(this.lstMapType);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.gMapControl);
            this.Controls.Add(this.lblMsgLength);
            this.Controls.Add(this.txtMessage);
            this.Controls.Add(this.lblSearch);
            this.Controls.Add(this.lblRadius);
            this.Controls.Add(this.trackBar1);
            this.Controls.Add(this.radioButton4);
            this.Controls.Add(this.radioButton3);
            this.Controls.Add(this.radioButton2);
            this.Controls.Add(this.radioButton1);
            this.Controls.Add(this.statusStrip1);
            this.Name = "frmApp";
            this.Text = "Simhasth Mahakumbh Ujjain 2016 - Indian Medical Association";
            this.Load += new System.EventHandler(this.frmApp_Load);
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarZoom)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.Label lblRadius;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.TextBox txtMessage;
        private System.Windows.Forms.Label lblMsgLength;
        private GMap.NET.WindowsForms.GMapControl gMapControl;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.ListBox lstMapType;
        private System.Windows.Forms.Label lblMap;
        private System.Windows.Forms.RadioButton radioButton4;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.TrackBar trackBarZoom;
        private System.Windows.Forms.Label lblZoom;
        private System.Windows.Forms.TextBox txtSid;
        private System.Windows.Forms.TextBox txtToken;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtNumber;
        private System.Windows.Forms.ListBox lstMsgResponse;
        private System.Windows.Forms.TextBox txtAuthKey;
        private System.Windows.Forms.TextBox txtSenderId;
        private System.Windows.Forms.TextBox txtWebResponse;
    }
}

