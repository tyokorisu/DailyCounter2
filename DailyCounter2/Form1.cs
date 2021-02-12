using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DailyCounter2
{
    public partial class Form1 : Form
    {
        //クエスト名のリスト
        List<string> questNameLists = new List<string>();

        //残り回数のリスト
        List<string> questCountLists = new List<string>();

        //ラベル&テキストボックス配列の宣言だけ、スコープの関係のせいかここじゃなきゃダメだった
        Label[] questNameLabels;
        TextBox[] questCountBoxes;


        public Form1()
        {
            InitializeComponent();

            //ラベル配列に初期値を入れる
            questNameLabels = new Label[14]{
                    questNameLabel0, questNameLabel1, questNameLabel2, questNameLabel3,
                    questNameLabel4, questNameLabel5, questNameLabel6, questNameLabel7,
                    questNameLabel8, questNameLabel9, questNameLabel10, questNameLabel11,
                    questNameLabel12, questNameLabel13};

            //テキストボックス配列に初期値を入れる
            questCountBoxes = new TextBox[14]{
                    questCountBox0, questCountBox1, questCountBox2, questCountBox3,
                    questCountBox4, questCountBox5, questCountBox6, questCountBox7,
                    questCountBox8, questCountBox9, questCountBox10, questCountBox11,
                    questCountBox12, questCountBox13};

            //txtファイルからデータを読み込む
            ReadFromFile();


        }
        
         void ReadFromFile()
        {

            using (System.IO.StreamReader file =
                new System.IO.StreamReader(@"QuestData.txt"))
            {
                while (!file.EndOfStream)
                {
                    //ファイルから1行を読み取り、行ごと文字列として返す
                    string line = file.ReadLine();

                    //読み込んだデータをクエスト名、残り回数に分割する
                    string[] data = line.Split(',');

                    //↑で分割したデータをそれぞれのリストへ入れる
                    this.questNameLists.Add(data[0]);
                    this.questCountLists.Add(data[1]);
                }


                //各Listの値を各コントロールの配列へ代入
                for (int i = 0; i < questNameLists.Count; i++)
                {
                    questNameLabels[i].Text = questNameLists[i];
                    questCountBoxes[i].Text = questCountLists[i];

                    //リセットする時用にTagにも入れておく
                    questNameLabels[i].Tag = questNameLists[i];
                    questCountBoxes[i].Tag = questCountLists[i];
                }

            }
        }

        private void buttonPlus_Click(object sender, EventArgs e)
        {
            //クリックされたボタンコントロールを取得
            Button button = (Button)sender;

            //クリックされたボタン名の最後の数字を抜き出して、
            //そのボタンの左にあるテキストボックスの名前の末尾に付け足して合体
            string textBoxName = "questCountBox" + button.Name.Substring("buttonPlus".Length);

            //↑の名前のテキストボックスコントロールを取得
            TextBox targetTextBox = (TextBox)this.Controls[textBoxName];

            //テキストボックスに入っている数字を取得
            int count = int.Parse(targetTextBox.Text);
            count++;
            targetTextBox.Text = count.ToString();
            if(count >0) targetTextBox.BackColor = Color.White;
        }

        private void buttonMinus_Click(object sender, EventArgs e)
        {
            //クリックされたボタンコントロールを取得
            Button button = (Button)sender;

            //クリックされたボタン名の最後の数字を抜き出して、
            //そのボタンの左にあるテキストボックスの名前の末尾に付け足して合体
            string textBoxName = "questCountBox" + button.Name.Substring("buttonMinus".Length);

            //↑の名前のテキストボックスコントロールを取得
            TextBox targetTextBox = (TextBox)this.Controls[textBoxName];

            //テキストボックスに入っている数字を取得
            int count = int.Parse(targetTextBox.Text);

            if (count > 0)
            {
                // 1以上なら減らす
                count--;
                // 数字をTextBoxのテキストに戻す
                targetTextBox.Text = count.ToString();
                // 0になったらグレーに
                if (count == 0)
                    targetTextBox.BackColor = Color.Gray;
            }
        }

        //リセットボタン
        void buttonCountReset_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("残り回数をリセットしますか？",
                  "確認",
                  MessageBoxButtons.YesNo,
                  MessageBoxIcon.Question,
                  MessageBoxDefaultButton.Button2);

            //何が選択されたか調べる
            if (result == DialogResult.Yes)
            {
                //「はい」が選択された時
                // 用意しておいたquestCountBoxes.Tagを同変数の.Textに入れ直す
                for (int i = 0; i < questNameLists.Count; i++)
                {
                    questCountBoxes[i].Text = questCountBoxes[i].Tag.ToString();
                    questCountBoxes[i].BackColor = Color.White;
                }

            }
            else if (result == DialogResult.No)
            {
                //「いいえ」が選択された時

            }
        }
        
        //フォーム終了時にテキストボックスに入っている値をプロパティに保存する
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.questCountBox0 = int.Parse(this.questCountBox0.Text);
            Properties.Settings.Default.questCountBox1 = int.Parse(this.questCountBox1.Text);
            Properties.Settings.Default.questCountBox2 = int.Parse(this.questCountBox2.Text);
            Properties.Settings.Default.questCountBox3 = int.Parse(this.questCountBox3.Text);
            Properties.Settings.Default.questCountBox4 = int.Parse(this.questCountBox4.Text);
            Properties.Settings.Default.questCountBox5 = int.Parse(this.questCountBox5.Text);
            Properties.Settings.Default.questCountBox6 = int.Parse(this.questCountBox6.Text);
            Properties.Settings.Default.questCountBox7 = int.Parse(this.questCountBox7.Text);
            Properties.Settings.Default.questCountBox8 = int.Parse(this.questCountBox8.Text);
            Properties.Settings.Default.questCountBox9 = int.Parse(this.questCountBox9.Text);
            Properties.Settings.Default.questCountBox10 = int.Parse(this.questCountBox10.Text);
            Properties.Settings.Default.questCountBox11 = int.Parse(this.questCountBox11.Text);
            Properties.Settings.Default.questCountBox12 = int.Parse(this.questCountBox12.Text);
            Properties.Settings.Default.questCountBox13 = int.Parse(this.questCountBox13.Text);

            Properties.Settings.Default.prevlocation = this.Location;

            Properties.Settings.Default.Save();
            
        }

        //フォームロード時にプロパティに保存された値を呼び戻す
        //ついでに値が0だったら色を灰色にする
        private void Form1_Load(object sender, EventArgs e)
        {
            
            this.questCountBox0.Text = Properties.Settings.Default.questCountBox0.ToString();
            this.questCountBox1.Text = Properties.Settings.Default.questCountBox1.ToString();
            this.questCountBox2.Text = Properties.Settings.Default.questCountBox2.ToString();
            this.questCountBox3.Text = Properties.Settings.Default.questCountBox3.ToString();
            this.questCountBox4.Text = Properties.Settings.Default.questCountBox4.ToString();
            this.questCountBox5.Text = Properties.Settings.Default.questCountBox5.ToString();
            this.questCountBox6.Text = Properties.Settings.Default.questCountBox6.ToString();
            this.questCountBox7.Text = Properties.Settings.Default.questCountBox7.ToString();
            this.questCountBox8.Text = Properties.Settings.Default.questCountBox8.ToString();
            this.questCountBox9.Text = Properties.Settings.Default.questCountBox9.ToString();
            this.questCountBox10.Text = Properties.Settings.Default.questCountBox10.ToString();
            this.questCountBox11.Text = Properties.Settings.Default.questCountBox11.ToString();
            this.questCountBox12.Text = Properties.Settings.Default.questCountBox12.ToString();
            this.questCountBox13.Text = Properties.Settings.Default.questCountBox13.ToString();


            if (questCountBox0.Text == "0") questCountBox0.BackColor = Color.Gray;
            if (questCountBox1.Text == "0") questCountBox1.BackColor = Color.Gray;
            if (questCountBox2.Text == "0") questCountBox2.BackColor = Color.Gray;
            if (questCountBox3.Text == "0") questCountBox3.BackColor = Color.Gray;
            if (questCountBox4.Text == "0") questCountBox4.BackColor = Color.Gray;
            if (questCountBox5.Text == "0") questCountBox5.BackColor = Color.Gray;
            if (questCountBox6.Text == "0") questCountBox6.BackColor = Color.Gray;
            if (questCountBox7.Text == "0") questCountBox7.BackColor = Color.Gray;
            if (questCountBox8.Text == "0") questCountBox8.BackColor = Color.Gray;
            if (questCountBox9.Text == "0") questCountBox9.BackColor = Color.Gray;
            if (questCountBox10.Text == "0") questCountBox10.BackColor = Color.Gray;
            if (questCountBox11.Text == "0") questCountBox11.BackColor = Color.Gray;
            if (questCountBox12.Text == "0") questCountBox12.BackColor = Color.Gray;
            if (questCountBox13.Text == "0") questCountBox13.BackColor = Color.Gray;

            this.Location = Properties.Settings.Default.prevlocation;
        }

    }

    
}
