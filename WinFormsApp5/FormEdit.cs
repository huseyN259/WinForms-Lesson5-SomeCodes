namespace WinFormsApp5;

public partial class FormEdit : Form
{
    public Product? EditProduct { get; set; }
    private bool _hasChanged = false;

    public FormEdit(Product product)
    {
        InitializeComponent();

        EditProduct = product;
        FillTextBoxText();
    }

    private void FillTextBoxText()
    {
        txt_name.Text = EditProduct?.Name;
        txt_price.Text = EditProduct?.Price.ToString();
        txt_discount.Text = EditProduct?.Discount.ToString();

        _hasChanged = false;
    }

    private void FormEdit_Load(object sender, EventArgs e)
    {
        if (EditProduct is null)
            return;

        txt_name.Text = EditProduct?.Name;
        txt_price.Text = EditProduct?.Price.ToString();
        txt_discount.Text = EditProduct?.Discount.ToString();
    }

    private void btn_save_Click(object sender, EventArgs e)
    {
        /*
         Close();
         Hide();
         Show();
        */

        if (!_hasChanged)
        {
            DialogResult = DialogResult.OK;
            return;
        }

        System.Text.StringBuilder sb = new();

        if (string.IsNullOrWhiteSpace(txt_name.Text))
            sb.Append("* Name is wrong\n");

        if (!decimal.TryParse(txt_price.Text, out decimal price))
            sb.Append("* Price is wrong\n");

        if (!byte.TryParse(txt_discount.Text, out byte discount))
            sb.Append("* Discount is wrong\n");

        if (sb.Length > 0)
        {
            MessageBox.Show(sb.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        if (EditProduct is null)
            return;

        EditProduct.Name = txt_price.Text;
        EditProduct.Price = price;
        EditProduct.Discount = discount;

        DialogResult = DialogResult.OK;
    }

    private void txt_TextChanged(object sender, EventArgs e) => _hasChanged = true;

    private void btn_cancel_Click(object sender, EventArgs e) => DialogResult = DialogResult.Cancel;

    public DialogResult ShowDialog(Product product)
    {
        FillTextBoxText();
        EditProduct = product;

        return ShowDialog();
    }
}