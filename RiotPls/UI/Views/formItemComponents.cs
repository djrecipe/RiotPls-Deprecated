using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using RiotPls.API.Serialization.Items;
using RiotPls.UI.Controls;
using RiotPls.UI.Models;

namespace RiotPls.UI.Views
{
    public class formItemComponents : Form
    {
        #region Static Members
        private static formItemComponents form = null;
        #endregion
        #region Static Methods
        public static void HideForm()
        {
            if(formItemComponents.form != null && formItemComponents.form.Visible)
                formItemComponents.form.Close();
            return;
        }
        public static void Show(ItemInfo item, Point location)
        {
            formItemComponents.form = new formItemComponents(item);
            formItemComponents.form.Location = location;
            formItemComponents.form.Show();
            return;
        }
        #endregion
        #region Instance Members
        private System.ComponentModel.IContainer components = null;
        private formItemComponentsModel model = null;
        #endregion
        #region Instance Methods
        private formItemComponents(ItemInfo item)
        {
            this.InitializeComponent();
            this.model = new formItemComponentsModel(item);
            DropSlot first_slot = null;
            Dictionary<DropSlot, List<DropSlot>> slots = this.model.GenerateDropSlots(out first_slot);
            this.Width = this.AddSlots(slots, slots[first_slot], 10, 10);
            return;
        }

        private int AddSlots(Dictionary<DropSlot, List<DropSlot>> all_slots, List<DropSlot> slots, int start_x, int start_y)
        {
            int x = start_x;
            foreach (DropSlot slot in slots)
            {
                slot.Location = new Point(x, start_y);
                x += slot.Width + 10;
                this.Controls.Add(slot);
                if (all_slots.ContainsKey(slot))
                {
                    this.AddSlots(all_slots, all_slots[slot], slot.Left - slot.Width/2, start_y + slot.Height + 10);
                }
            }
            return x;
        }
        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // formItemComponents
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(120, 150);
            this.ControlBox = false;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(120, 150);
            this.Name = "formItemComponents";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "formItemComponents";
            this.Load += new System.EventHandler(this.formItemComponents_Load);
            this.MouseLeave += new System.EventHandler(this.formItemComponents_MouseLeave);
            this.ResumeLayout(false);

        }
        #endregion
        #region Event Methods
        private void formItemComponents_Load(object sender, System.EventArgs e)
        {
            return;
        }
        private void formItemComponents_MouseLeave(object sender, System.EventArgs e)
        {
            this.Close();
            return;
        }
        #endregion
        #region Override Methods
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

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            base.OnPaintBackground(e);
            Rectangle rect = new Rectangle(this.ClientRectangle.Left+1, this.ClientRectangle.Top + 1, this.ClientRectangle.Width - 2, this.ClientRectangle.Height -2 );
            e.Graphics.DrawRectangle(new Pen(Color.Blue), rect);
            return;
        }
        #endregion
    }
}
