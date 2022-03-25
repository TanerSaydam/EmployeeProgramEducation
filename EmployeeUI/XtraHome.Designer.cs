namespace EmployeeUI
{
    partial class XtraHome
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(XtraHome));
            this.ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.btnEmployee = new DevExpress.XtraBars.BarButtonItem();
            this.btnClose = new DevExpress.XtraBars.BarButtonItem();
            this.btnDepartment = new DevExpress.XtraBars.BarButtonItem();
            this.btnEmployeeAdd = new DevExpress.XtraBars.BarButtonItem();
            this.btnOffDayAdd = new DevExpress.XtraBars.BarButtonItem();
            this.btnOffDayList = new DevExpress.XtraBars.BarButtonItem();
            this.btnPayrollParameter = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup3 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup4 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.xtraTabbedMdiManager1 = new DevExpress.XtraTabbedMdi.XtraTabbedMdiManager(this.components);
            this.btnPayroll = new DevExpress.XtraBars.BarButtonItem();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabbedMdiManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbonControl1
            // 
            this.ribbonControl1.ExpandCollapseItem.Id = 0;
            this.ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl1.ExpandCollapseItem,
            this.ribbonControl1.SearchEditItem,
            this.btnEmployee,
            this.btnClose,
            this.btnDepartment,
            this.btnEmployeeAdd,
            this.btnOffDayAdd,
            this.btnOffDayList,
            this.btnPayrollParameter,
            this.btnPayroll});
            this.ribbonControl1.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl1.MaxItemId = 9;
            this.ribbonControl1.Name = "ribbonControl1";
            this.ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.ribbonControl1.Size = new System.Drawing.Size(1055, 150);
            // 
            // btnEmployee
            // 
            this.btnEmployee.Caption = "Personel Listesi";
            this.btnEmployee.Id = 1;
            this.btnEmployee.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnEmployee.ImageOptions.Image")));
            this.btnEmployee.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnEmployee.ImageOptions.LargeImage")));
            this.btnEmployee.Name = "btnEmployee";
            this.btnEmployee.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnEmployee_ItemClick);
            // 
            // btnClose
            // 
            this.btnClose.Caption = "Kapat";
            this.btnClose.Id = 2;
            this.btnClose.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.ImageOptions.Image")));
            this.btnClose.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnClose.ImageOptions.LargeImage")));
            this.btnClose.Name = "btnClose";
            this.btnClose.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnClose_ItemClick);
            // 
            // btnDepartment
            // 
            this.btnDepartment.Caption = "Personel Bölümleri";
            this.btnDepartment.Id = 3;
            this.btnDepartment.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnDepartment.ImageOptions.Image")));
            this.btnDepartment.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnDepartment.ImageOptions.LargeImage")));
            this.btnDepartment.Name = "btnDepartment";
            this.btnDepartment.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnDepartment_ItemClick);
            // 
            // btnEmployeeAdd
            // 
            this.btnEmployeeAdd.Caption = "Personel Ekle";
            this.btnEmployeeAdd.Id = 4;
            this.btnEmployeeAdd.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnEmployeeAdd.ImageOptions.Image")));
            this.btnEmployeeAdd.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnEmployeeAdd.ImageOptions.LargeImage")));
            this.btnEmployeeAdd.Name = "btnEmployeeAdd";
            this.btnEmployeeAdd.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnEmployeeAdd_ItemClick);
            // 
            // btnOffDayAdd
            // 
            this.btnOffDayAdd.Caption = "Persone İzin Girişi";
            this.btnOffDayAdd.Id = 5;
            this.btnOffDayAdd.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnOffDayAdd.ImageOptions.Image")));
            this.btnOffDayAdd.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnOffDayAdd.ImageOptions.LargeImage")));
            this.btnOffDayAdd.Name = "btnOffDayAdd";
            this.btnOffDayAdd.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnOffDayAdd_ItemClick);
            // 
            // btnOffDayList
            // 
            this.btnOffDayList.Caption = "Personel İzin Listesi";
            this.btnOffDayList.Id = 6;
            this.btnOffDayList.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnOffDayList.ImageOptions.Image")));
            this.btnOffDayList.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnOffDayList.ImageOptions.LargeImage")));
            this.btnOffDayList.Name = "btnOffDayList";
            this.btnOffDayList.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnOffDayList_ItemClick);
            // 
            // btnPayrollParameter
            // 
            this.btnPayrollParameter.Caption = "Bordro Parametereleri";
            this.btnPayrollParameter.Id = 7;
            this.btnPayrollParameter.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnPayrollParameter.ImageOptions.Image")));
            this.btnPayrollParameter.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnPayrollParameter.ImageOptions.LargeImage")));
            this.btnPayrollParameter.Name = "btnPayrollParameter";
            this.btnPayrollParameter.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnPayrollParameter_ItemClick);
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup3,
            this.ribbonPageGroup1,
            this.ribbonPageGroup4,
            this.ribbonPageGroup2});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "Personel Takip";
            // 
            // ribbonPageGroup3
            // 
            this.ribbonPageGroup3.ItemLinks.Add(this.btnEmployee);
            this.ribbonPageGroup3.ItemLinks.Add(this.btnDepartment);
            this.ribbonPageGroup3.ItemLinks.Add(this.btnOffDayList);
            this.ribbonPageGroup3.ItemLinks.Add(this.btnPayroll);
            this.ribbonPageGroup3.Name = "ribbonPageGroup3";
            this.ribbonPageGroup3.Text = "Listeler";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.ItemLinks.Add(this.btnEmployeeAdd);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnOffDayAdd);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.Text = "Kayıt";
            // 
            // ribbonPageGroup4
            // 
            this.ribbonPageGroup4.ItemLinks.Add(this.btnPayrollParameter);
            this.ribbonPageGroup4.Name = "ribbonPageGroup4";
            this.ribbonPageGroup4.Text = "Parametler";
            // 
            // ribbonPageGroup2
            // 
            this.ribbonPageGroup2.ItemLinks.Add(this.btnClose);
            this.ribbonPageGroup2.Name = "ribbonPageGroup2";
            this.ribbonPageGroup2.Text = "Kapat";
            // 
            // xtraTabbedMdiManager1
            // 
            this.xtraTabbedMdiManager1.MdiParent = this;
            // 
            // btnPayroll
            // 
            this.btnPayroll.Caption = "Bordro";
            this.btnPayroll.Id = 8;
            this.btnPayroll.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barButtonItem1.ImageOptions.Image")));
            this.btnPayroll.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barButtonItem1.ImageOptions.LargeImage")));
            this.btnPayroll.Name = "btnPayroll";
            this.btnPayroll.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnPayroll_ItemClick);
            // 
            // XtraHome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1055, 639);
            this.Controls.Add(this.ribbonControl1);
            this.IsMdiContainer = true;
            this.Name = "XtraHome";
            this.Text = "Personel Takip Formu";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.XtraHome_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabbedMdiManager1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        private DevExpress.XtraBars.BarButtonItem btnEmployee;
        private DevExpress.XtraBars.BarButtonItem btnClose;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup2;
        private DevExpress.XtraBars.BarButtonItem btnDepartment;
        private DevExpress.XtraTabbedMdi.XtraTabbedMdiManager xtraTabbedMdiManager1;
        private DevExpress.XtraBars.BarButtonItem btnEmployeeAdd;
        private DevExpress.XtraBars.BarButtonItem btnOffDayAdd;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup3;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup4;
        private DevExpress.XtraBars.BarButtonItem btnOffDayList;
        private DevExpress.XtraBars.BarButtonItem btnPayrollParameter;
        private DevExpress.XtraBars.BarButtonItem btnPayroll;
    }
}