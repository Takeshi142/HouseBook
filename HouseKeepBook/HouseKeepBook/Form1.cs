using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HouseKeepBook
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            LoadData();
            //データテーブルに分類と入出金分類を振り分ける
            categoryDataSet1.CategoryDataTable.AddCategoryDataTableRow("給料", "入金");
            categoryDataSet1.CategoryDataTable.AddCategoryDataTableRow("食費", "出金");
            categoryDataSet1.CategoryDataTable.AddCategoryDataTableRow("雑費", "出金");
            categoryDataSet1.CategoryDataTable.AddCategoryDataTableRow("住居", "出金");
        }

        //新規追加処理
        private void AddData()
        { 
            ItemForm frmItem = new ItemForm(categoryDataSet1);
            DialogResult drRet = frmItem.ShowDialog();

            if (drRet == DialogResult.OK)
            {
                if (frmItem.mtxtMoney.Text == null || frmItem.mtxtMoney.Text == "")
                {
                    frmItem.mtxtMoney.Text = "0";
                }
                    moneyDataSet.moneyDataTable.AddmoneyDataTableRow(
                    frmItem.monCalendar.SelectionRange.Start,
                    frmItem.cmbCategory.Text,
                    frmItem.txtItem.Text,
                    int.Parse(frmItem.mtxtMoney.Text),
                    frmItem.txtRemarks.Text
                    );
            }
        }

        //<保存>データテーブルの書き込みされたデータをファイルに書き込み保存する
        private void SaveData()
        {
            string path = "MoneyData.csv";
            string strData = "";

            System.IO.StreamWriter sw = new System.IO.StreamWriter(
                path,
                false,
                System.Text.Encoding.Default);
            foreach(MoneyDataSet.moneyDataTableRow drMoney in moneyDataSet.moneyDataTable)
            {
                strData = drMoney.日付.ToShortDateString() + ","
                    + drMoney.分類 + ","
                    + drMoney.品名 + ","
                    + drMoney.分類.ToString() + ","
                    + drMoney.分類;
                sw.WriteLine(strData);
            }
            sw.Close();
        }

        //<読み込み>ファイルの読み込みを行いForm1のデータテーブルに表示させる
        private void LoadData()
        {
            string path = "MoneyData.csv";
            string delimStr = ",";
            char[] delimiter = delimStr.ToCharArray();
            string strLine;
            string[] strData;
            bool fileExists = System.IO.File.Exists(path);
            if (fileExists)
            {
                System.IO.StreamReader sr = new System.IO.StreamReader(path,System.Text.Encoding.Default);
                while(sr.Peek() >= 0)
                {
                    strLine = sr.ReadLine();
                    strData = strLine.Split(delimiter);
                    moneyDataSet.moneyDataTable.AddmoneyDataTableRow(
                        DateTime.Parse(strData[0]),
                        strData[1],
                        strData[2],
                        int.Parse(strData[3]),
                        strData[4]
                        );
                }
                sr.Close();
            }
 
        }

        //<変更>選択している行を取得してインスタンス作成、OKを選択したら入力したデータを上書きする
        private void UpdateData()
        {
            int nowRow = dgv.CurrentRow.Index;
            DateTime oldDate = DateTime.Parse(dgv.Rows[nowRow].Cells[0].Value.ToString());
            string oldCategory = dgv.Rows[nowRow].Cells[1].Value.ToString();
            string oldItem = dgv.Rows[nowRow].Cells[2].Value.ToString();
            int oldMoney = int.Parse(dgv.Rows[nowRow].Cells[3].Value.ToString());
            string oldRemarks = dgv.Rows[nowRow].Cells[4].Value.ToString();

            ItemForm frmItem = new ItemForm(categoryDataSet1,oldDate,oldCategory,oldItem,oldMoney,oldRemarks);
            DialogResult drRet = frmItem.ShowDialog();
            if (frmItem.mtxtMoney.Text == null || frmItem.mtxtMoney.Text == "")
            {
                frmItem.mtxtMoney.Text = "0";
            }
            if (drRet == DialogResult.OK)
            {
                dgv.Rows[nowRow].Cells[0].Value = frmItem.monCalendar.SelectionRange.Start;
                dgv.Rows[nowRow].Cells[1].Value = frmItem.cmbCategory.Text;
                dgv.Rows[nowRow].Cells[2].Value = frmItem.txtItem.Text;
                dgv.Rows[nowRow].Cells[3].Value = int.Parse(frmItem.mtxtMoney.Text);
                dgv.Rows[nowRow].Cells[4].Value = frmItem.txtRemarks.Text;
            }

        }

        //<削除>選択している行のデータをを削除
        private void DeleteData()
        {
            int nowRow = dgv.CurrentRow.Index;
            dgv.Rows.RemoveAt(nowRow);
        }

        //集計表示
        private void CalcSummary()
        {
            string expression;
            //集計データテーブルを初期化
            summaryDataSet.SumDataTable.Clear();
            //一覧表示のテーブルのレコード数繰り返す
            //foreachで列データをdrMoneyに代入して一列ずつ選択する
            foreach(MoneyDataSet.moneyDataTableRow drMoney in moneyDataSet.moneyDataTable)
            {
                expression = "日付= '" + drMoney.日付.ToShortDateString() + "'";
                //SumDataTableの中に同じ日があるかどうかのを判定、ない場合場合配列には何も入らないから0、あった場合はcurDRに配列が追加
                SummaryDataSet.SumDataTableRow[] curDR = (SummaryDataSet.SumDataTableRow[])summaryDataSet.SumDataTable.Select(expression);

                //同じ日のデータがない場合、新しくSumDataTableに項目を追加
                if(curDR.Length == 0)
                {
                    CategoryDataSet.CategoryDataTableRow[] selectedDataRow;

                    selectedDataRow = (CategoryDataSet.CategoryDataTableRow[])
                        categoryDataSet1.CategoryDataTable.Select("分類 = '" + drMoney.分類 + "'");

                    if(selectedDataRow[0].入出金分類 == "入金")
                    {
                        summaryDataSet.SumDataTable.AddSumDataTableRow(drMoney.日付, drMoney.金額, 0);
                    }
                    else if (selectedDataRow[0].入出金分類 == "出金")
                    {
                        summaryDataSet.SumDataTable.AddSumDataTableRow(drMoney.日付,0,drMoney.金額);
                    }
                }
                    //同じ日のデータがまだあった場合
                else
                {
                    CategoryDataSet.CategoryDataTableRow[] selectedDataRow;
                    selectedDataRow = (CategoryDataSet.CategoryDataTableRow[])
                        categoryDataSet1.CategoryDataTable.Select("分類 = '" + drMoney.分類 + "'");
                    if(selectedDataRow[0].入出金分類 == "入金")
                    {
                        curDR[0].入金合計 += drMoney.金額;
                    }
                    else if (selectedDataRow[0].入出金分類 == "出金")
                    {
                        curDR[0].出金合計 += drMoney.金額;
                    }
                }
            }
        }

        //追加ボタン
        private void 追加AToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddData();
        }
        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            AddData();
        }
        //終了ボタン
        private void ButtonEnd_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void 終了XToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //保存ボタン
        private void 保存SToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveData();
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveData();
        }
        //変更ボタン
        private void ButtonChange_Click(object sender, EventArgs e)
        {
            UpdateData();
        }
        private void 変更ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdateData();
        }
        //削除ボタン
        private void Button3Delete_Click(object sender, EventArgs e)
        {
            DeleteData();
        }
        private void 削除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeleteData();
        }

        private void TabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            CalcSummary();
        }

        private void 一覧表示LToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(tabList);
        }
        private void 集計表時ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(tabSummary);
        }
    }
}
