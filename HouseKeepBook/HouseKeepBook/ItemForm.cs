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
    public partial class ItemForm : Form
    {
        public ItemForm(CategoryDataSet dsCategory)
        {
            InitializeComponent();
            //引数のデータセットの値をデータセットに代入
            categoryDataSet.Merge(dsCategory);
        }
        //追加用コンストラクタ
        public ItemForm(
            CategoryDataSet dsCategory,
            DateTime nowDate,
            string category,
            string item,
            int money,
            string remarks)
        {
            InitializeComponent();
            categoryDataSet.Merge(dsCategory);
            monCalendar.SetDate(nowDate);
            cmbCategory.Text = category;
            txtItem.Text = item;
            mtxtMoney.Text = money.ToString();
            txtRemarks.Text = remarks;
        }

        private ItemForm()
        {

        }
        private void ItemForm_Load(object sender, EventArgs e)
        {

        }
    }
}
