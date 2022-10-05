namespace WinFormsApp5;

public partial class FormMain : Form
{
    private Product? _selectedProduct = null;

    public FormMain()
    {
        InitializeComponent();
    }

    private void btn_load_Click(object sender, EventArgs e)
    {
        _selectedProduct = new Product()
        {
            Id = 1,
            Name = "Iphone 14 Pro Max",
            Price = 3500,
            Discount = 0
        };

        FillTextBoxText(_selectedProduct);
    }

    private void button1_Click(object sender, EventArgs e)
    {
        if (_selectedProduct is null)
            return;

        // way 1: with Property or Field
        /*FormEdit formEdit = new FormEdit();
        formEdit.EditProduct = _selectedProduct;*/

        // way 2: with Constructor is the best way !
        FormEdit formEdit = new FormEdit(_selectedProduct);
        DialogResult result = formEdit.ShowDialog(_selectedProduct);

        // way 3: with ShowDialog overloading (Method) = ShowDialog()
        //FormEdit formEdit = new FormEdit(_selectedProduct);

        if (result == DialogResult.OK)
            FillTextBoxText(formEdit.EditProduct);
        else
            MessageBox.Show("Cancel", 
                "Information", 
                MessageBoxButtons.OK, 
                MessageBoxIcon.Information);
    }

    private void FillTextBoxText(Product? product)
    {
        if (product is null)
            return;

        txt_id.Text = product.Id.ToString();
        txt_name.Text = product.Name?.ToString();
        txt_discount.Text = product.Discount.ToString();
        txt_price.Text = product.Price.ToString();
    }
}