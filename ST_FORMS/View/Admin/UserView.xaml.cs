using ST_Datos.Rol;
using ST_Entidades.Rol;
using ST_Negocio.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static DevExpress.Data.Helpers.ExpressiveSortInfo;

namespace ST_FORMS.View.Admin
{
    /// <summary>
    /// Lógica de interacción para UserView.xaml
    /// </summary>
    public partial class UserView : UserControl
    {
        private CN_Usuario _usuarioRepository;
        private int _selectedRowIndex = -1;

        public UserView()
        {
            InitializeComponent();
            _usuarioRepository = new CN_Usuario();
            Loaded += UserView_Load;
        }

        private void UserView_Load(object sender, RoutedEventArgs e)
        {
            CargarCombos();
            CargarUsuarios();
            CargarOpcionesBusqueda();
        }

        private void CargarCombos()
        {
            cboEstado.Items.Add(new { Valor = 1, Texto = "Activo" });
            cboEstado.Items.Add(new { Valor = 0, Texto = "No Activo" });
            cboEstado.DisplayMemberPath = "Texto";
            cboEstado.SelectedValuePath = "Valor";
            cboEstado.SelectedIndex = 0;

            List<e_Rol> listaRol = new CN_Rol().Listar();
            foreach (e_Rol item in listaRol)
            {
                cboRol.Items.Add(new { Valor = item.IdRol, Texto = item.Descripcion });
            }
            cboRol.DisplayMemberPath = "Texto";
            cboRol.SelectedValuePath = "Valor";
            cboRol.SelectedIndex = 0;
        }

        private void CargarUsuarios()
        {
            List<Usuario> listaUsuario = _usuarioRepository.Listar();
            foreach (Usuario item in listaUsuario)
            {
                dgvData.Items.Add(new UsuarioDataGridItem
                {
                    IdUsuario = item.IdUsuario,
                    Documento = item.Documento,
                    NombreCompleto = item.NombreCompleto,
                    Correo = item.Correo,
                    Clave = item.Clave,
                    Rol = item.oRol.Descripcion,
                    Estado = item.Estado ? "Activo" : "No Activo"
                });
            }
        }

        private void CargarOpcionesBusqueda()
        {
            cboBusqueda.Items.Add(new { Valor = "Documento", Texto = "Documento" });
            cboBusqueda.Items.Add(new { Valor = "NombreCompleto", Texto = "Nombre Completo" });
            cboBusqueda.Items.Add(new { Valor = "Correo", Texto = "Correo" });
            cboBusqueda.Items.Add(new { Valor = "Rol", Texto = "Rol" });
            cboBusqueda.Items.Add(new { Valor = "Estado", Texto = "Estado" });
            cboBusqueda.DisplayMemberPath = "Texto";
            cboBusqueda.SelectedValuePath = "Valor";
            cboBusqueda.SelectedIndex = 0;
        }

        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            string mensaje = string.Empty;

            int idUsuario = 0;
            if (!string.IsNullOrWhiteSpace(txtId.Text))
            {
                int.TryParse(txtId.Text, out idUsuario);
            }

            int idRol = 0;
            if (cboRol.SelectedValue != null)
            {
                int.TryParse(cboRol.SelectedValue.ToString(), out idRol);
            }

            bool estado = false;
            if (cboEstado.SelectedValue != null)
            {
                estado = Convert.ToInt32(cboEstado.SelectedValue) == 1;
            }

            Usuario objUsuario = new Usuario()
            {
                IdUsuario = idUsuario,
                Documento = txtDocumento.Text,
                NombreCompleto = txtNombreCompleto.Text,
                Correo = txtCorreo.Text,
                Clave = txtClave.Password,
                oRol = new e_Rol() { IdRol = idRol, Descripcion = ((dynamic)cboRol.SelectedItem).Texto },
                Estado = estado
            };

            bool documentoDuplicado = false;
            foreach (var item in dgvData.Items)
            {
                if (item is UsuarioDataGridItem usuario)
                {
                    if (usuario.Documento == objUsuario.Documento && usuario.IdUsuario != objUsuario.IdUsuario)
                    {
                        documentoDuplicado = true;
                        break;
                    }
                }
            }

            if (documentoDuplicado)
            {
                MessageBox.Show("No se puede repetir el documento para más de un usuario.");
                return;
            }

            if (objUsuario.IdUsuario == 0)
            {
                int idUsuarioGenerado = _usuarioRepository.Registrar(objUsuario, out mensaje);
                if (idUsuarioGenerado != 0)
                {
                    objUsuario.IdUsuario = idUsuarioGenerado;
                    dgvData.Items.Add(new UsuarioDataGridItem
                    {
                        IdUsuario = objUsuario.IdUsuario,
                        Documento = objUsuario.Documento,
                        NombreCompleto = objUsuario.NombreCompleto,
                        Correo = objUsuario.Correo,
                        Clave = objUsuario.Clave,
                        Rol = objUsuario.oRol.Descripcion,
                        Estado = objUsuario.Estado ? "Activo" : "No Activo",
                        Visibility = Visibility.Visible
                    });
                    Limpiar();
                }
                else
                {
                    MessageBox.Show(mensaje);
                }
            }
            else
            {
                bool resultado = _usuarioRepository.Editar(objUsuario, out mensaje);
                if (resultado)
                {
                    var selectedRow = dgvData.Items[_selectedRowIndex] as UsuarioDataGridItem;
                    if (selectedRow != null)
                    {
                        selectedRow.Documento = objUsuario.Documento;
                        selectedRow.NombreCompleto = objUsuario.NombreCompleto;
                        selectedRow.Correo = objUsuario.Correo;
                        selectedRow.Clave = objUsuario.Clave;
                        selectedRow.Rol = objUsuario.oRol.Descripcion;
                        selectedRow.Estado = objUsuario.Estado ? "Activo" : "No Activo";
                        selectedRow.Visibility = Visibility.Visible;

                        dgvData.Items[_selectedRowIndex] = selectedRow;
                    }
                    dgvData.Items.Refresh();
                    Limpiar();
                }
                else
                {
                    MessageBox.Show(mensaje);
                }
            }
        }




        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            if (Convert.ToInt32(txtId.Text) != 0)
            {
                if (MessageBox.Show("¿Desea eliminar el usuario?", "Mensaje", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    string mensaje = string.Empty;
                    Usuario objUsuario = new Usuario() { IdUsuario = Convert.ToInt32(txtId.Text) };
                    bool respuesta = _usuarioRepository.Eliminar(objUsuario, out mensaje);
                    if (respuesta)
                    {
                        dgvData.Items.RemoveAt(_selectedRowIndex);
                        Limpiar();
                    }
                    else
                    {
                        MessageBox.Show(mensaje, "Mensaje", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                    }
                }
            }
        }

        private void btnBuscar_Click(object sender, RoutedEventArgs e)
        {
            string columnaFiltro = cboBusqueda.SelectedValue.ToString();
            string textoBusqueda = txtBusqueda.Text.ToUpper();

            foreach (var item in dgvData.Items)
            {
                if (item is UsuarioDataGridItem row)
                {
                    string valor = row.GetType().GetProperty(columnaFiltro).GetValue(row, null).ToString().ToUpper();
                    row.Visibility = valor.Contains(textoBusqueda) ? Visibility.Visible : Visibility.Collapsed;
                }
            }

            dgvData.Items.Refresh();
        }

        private void btnLimpiarBuscador_Click(object sender, RoutedEventArgs e)
        {
            txtBusqueda.Text = string.Empty;
            foreach (var item in dgvData.Items)
            {
                if (item is UsuarioDataGridItem row)
                {
                    row.Visibility = Visibility.Visible;
                }
            }

            dgvData.Items.Refresh();
        }

        private void btnLimpiar_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }

        private void Limpiar()
        {
            txtId.Text = "0";
            txtDocumento.Text = string.Empty;
            txtNombreCompleto.Text = string.Empty;
            txtCorreo.Text = string.Empty;
            txtClave.Password = string.Empty;
            cboRol.SelectedIndex = 0;
            cboEstado.SelectedIndex = 0;
            _selectedRowIndex = -1;
        }

        private void dgvData_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedRow = dgvData.SelectedItem as UsuarioDataGridItem;
            if (selectedRow != null)
            {
                txtId.Text = selectedRow.IdUsuario.ToString();
                txtDocumento.Text = selectedRow.Documento;
                txtNombreCompleto.Text = selectedRow.NombreCompleto;
                txtCorreo.Text = selectedRow.Correo;
                txtClave.Password = selectedRow.Clave;

                foreach (var item in cboRol.Items)
                {
                    dynamic rol = item;
                    if (rol.Texto == selectedRow.Rol)
                    {
                        cboRol.SelectedItem = item;
                        break;
                    }
                }

                foreach (var item in cboEstado.Items)
                {
                    dynamic estado = item;
                    if (estado.Texto == selectedRow.Estado)
                    {
                        cboEstado.SelectedItem = item;
                        break;
                    }
                }

                _selectedRowIndex = dgvData.SelectedIndex;
            }
        }

        public class UsuarioDataGridItem
        {
            public int IdUsuario { get; set; }
            public string Documento { get; set; }
            public string NombreCompleto { get; set; }
            public string Correo { get; set; }
            public string Clave { get; set; }
            public string Rol { get; set; }
            public string Estado { get; set; }
            public Visibility Visibility { get; set; } = Visibility.Visible;
        }


    }
}
