using System;
using System.Windows.Forms;
using AdventureAdmin.Data.Models;
using AdventureAdmin.Ui.Services;

namespace AdventureAdmin.Ui.ProductCategory
{
    public partial class ProductCategoryForm : Form
    {
        private readonly ProductCategoryService _productCategoryService;
        private readonly Data.Models.ProductCategory? _categoria;

        public ProductCategoryForm(ProductCategoryService productCategoryService)
            : this(productCategoryService, null)
        {
        }

        public ProductCategoryForm(ProductCategoryService productCategoryService, Data.Models.ProductCategory? categoria)
        {
            InitializeComponent();
            _productCategoryService = productCategoryService;
            _categoria = categoria;

            if (_categoria != null)
            {
                CargarDatos(_categoria);
            }
        }

        private void CargarDatos(Data.Models.ProductCategory categoria)
        {
            txtName.Text = categoria.Name;
            dtpModifiedDate.Value = categoria.ModifiedDate;
            this.Text = $"Editar Categoría – {categoria.Name}";
        }

        private async void btnGuardar_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();

            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                errorProvider1.SetError(txtName, "El nombre es obligatorio.");
                return;
            }

            try
            {
                var categoria = _categoria ?? new Data.Models.ProductCategory
                {
                    Rowguid = Guid.NewGuid(),
                    ModifiedDate = DateTime.Now
                };

                categoria.Name = txtName.Text;
                categoria.ModifiedDate = DateTime.Now;

                var paso = await _productCategoryService.Guardar(categoria);

                if (!paso)
                {
                    MessageBox.Show("Error al guardar la categoría", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    var mensaje = _categoria == null ? "Categoría guardada correctamente" : "Categoría modificada correctamente";
                    MessageBox.Show(mensaje, "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dtpModifiedDate_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
