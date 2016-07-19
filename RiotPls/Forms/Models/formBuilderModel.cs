using RiotPls.API.Builder;
using RiotPls.Tools;

namespace RiotPls.Forms.Models
{
    public class formBuilderModel
    {
        public event IntegerDelegate RowChanged;
        public event VoidDelegate BuildChanged;
        public Build Build { get; set; }
        public formBuilderModel(Build build)
        {
            this.Build = build;
            this.Build.BuildChanged += this.Build_BuildChanged;
            this.Build.SelectedRowChanged += this.Build_SelectedRowChanged;
        }
        public void UpdateBuild()
        {
            if (this.BuildChanged != null)
                this.BuildChanged();
            return;
        }
        public void SelectRow(int row)
        {
            if (this.RowChanged != null)
                this.RowChanged(row);
            return;
        }
        private void Build_BuildChanged(string name)
        {
            this.UpdateBuild();
            return;
        }
        private void Build_SelectedRowChanged(int row)
        {
            this.SelectRow(row);
            return;
        }
    }
}
