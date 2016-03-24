using System.Drawing;
using Newtonsoft.Json;

namespace RiotPls.API.Serialization.Champions
{

    [JsonObject(MemberSerialization.OptIn)]
    public class RatingInfo
    {
        private int _Attack = -1;
        [JsonProperty("attack", Order = 1)]
        public int Attack
        {
            get
            {
                return this._Attack;
            }
            private set
            {
                this._Attack = value;
                this.AttackBitmap = this.CreateBitmap(this.Attack, Color.Red);
                return;
            }
        }
        private Bitmap _AttackBitmap = null;
        public Bitmap AttackBitmap
        {
            get
            {
                return this._AttackBitmap;
            }
            private set
            {
                this._AttackBitmap = value;
            }
        }
        private int _Defense = -1;
        [JsonProperty("defense", Order = 2)]
        public int Defense
        {
            get
            {
                return this._Defense;
            }
            private set
            {
                this._Defense = value;
                this.DefenseBitmap = this.CreateBitmap(this.Defense, Color.Green);
                return;
            }
        }
        private Bitmap _DefenseBitmap = null;
        public Bitmap DefenseBitmap
        {
            get
            {
                return this._DefenseBitmap;
            }
            private set
            {
                this._DefenseBitmap = value;
            }
        }
        private int _Difficulty = -1;
        [JsonProperty("difficulty", Order = 3)]
        public int Difficulty
        {
            get
            {
                return this._Difficulty;
            }
            private set
            {
                this._Difficulty = value;
                this.DifficultyBitmap = this.CreateBitmap(this.Difficulty, Color.Purple);
                return;
            }
        }
        private Bitmap _DifficultyBitmap = null;
        public Bitmap DifficultyBitmap
        {
            get
            {
                return this._DifficultyBitmap;
            }
            private set
            {
                this._DifficultyBitmap = value;
            }
        }
        private int _Magic = -1;
        [JsonProperty("magic", Order = 4)]
        public int Magic
        {
            get
            {
                return this._Magic;
            }
            private set
            {
                this._Magic = value;
                this.MagicBitmap = this.CreateBitmap(this.Magic, Color.Blue);
                return;
            }
        }
        private Bitmap _MagicBitmap = null;
        public Bitmap MagicBitmap
        {
            get
            {
                return this._MagicBitmap;
            }
            private set
            {
                this._MagicBitmap = value;
            }
        }
        private Bitmap CreateBitmap(int value, Color color)
        {
            Bitmap image = new Bitmap(50, 100);
            double ratio = (double)value / 10.0;
            int fill_bottom = (int)(ratio * (double)image.Height);
            Graphics g = Graphics.FromImage(image);
            g.FillRectangle(new SolidBrush(Color.FromArgb(46, 46, 46)), 0, 0, image.Width, image.Height);
            g.FillRectangle(new SolidBrush(color), new Rectangle(0, image.Height - fill_bottom, image.Width, fill_bottom));
            g.DrawRectangle(new Pen(Brushes.Black, 3.0f), new Rectangle(0, 0, image.Width - 1, image.Height - 1));
            return image;
        }
    }
}
