using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace presentacion
{
    public class Validaciones
    {
        
        public void soloLetras(KeyPressEventArgs e)
        {
            if (Char.IsLetter(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsSeparator(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsPunctuation(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsSymbol(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
                MessageBox.Show("Solo se permiten letras,símbolos y puntos...", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        public void soloNumeros(KeyPressEventArgs e)
        {
            if (Char.IsNumber(e.KeyChar) || (Char.IsPunctuation(e.KeyChar)))
            {
                e.Handled = false;
            }
            
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                
                e.Handled = true;
                MessageBox.Show("Solo se permiten números y puntos...", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

    }
}