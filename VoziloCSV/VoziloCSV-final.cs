using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VoziloCSV
{
    public partial class Form1 : Form
    {
        private int _motociklCount = 0;
        private int _automobilCount = 0;
        private int _kamionCount = 0;
        public Form1()
        {
            InitializeComponent();
        }
        private void btnUnesi_Click(object sender, EventArgs e)
        {
            txtModel.Clear();
            txtGodinaProizvodnje.Clear();
            txtBrojKotaca.Clear();
        }

        private void btnObradi_Click(object sender, EventArgs e)
        {
            if (!ValidateInput())
            {
                return;
            }

            string model = txtModel.Text;
            int godinaProizvodnje = int.Parse(txtGodinaProizvodnje.Text);
            int brojKotaca = int.Parse(txtBrojKotaca.Text);

            string kategorija = GetKategorija(brojKotaca);

            switch (kategorija)
            {
                case "Motocikl":
                    _motociklCount++;
                    break;
                case "Automobil":
                    _automobilCount++;
                    break;
                case "Kamion":
                    _kamionCount++;
                    break;
            }

            txtIspis.Text = $"Model: {model}\r\nGodina proizvodnje: {godinaProizvodnje}\r\nBroj kotača: {brojKotaca}\r\nKategorija: {kategorija}\r\n\r\n";
            txtIspis.Text += $"Ukupan broj vozila po kategorijama:\r\nMotocikl: {_motociklCount}\r\nAutomobil: {_automobilCount}\r\nKamion: {_kamionCount}";
        }

        private void btnIspis_Click(object sender, EventArgs e)
        {
            txtIspis.Clear();
        }
        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtModel.Text) || string.IsNullOrWhiteSpace(txtGodinaProizvodnje.Text) || string.IsNullOrWhiteSpace(txtBrojKotaca.Text))
            {

                MessageBox.Show("Sva polja moraju biti popunjena!", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

            if (!int.TryParse(txtGodinaProizvodnje.Text, out int godinaProizvodnje) || !int.TryParse(txtBrojKotaca.Text, out int brojKotaca))
            {
                 MessageBox.Show("Godina proizvodnje i broj kotača moraju biti brojevi!", "Error",
                 MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtGodinaProizvodnje.Focus();
                return false;
            }

            if (brojKotaca % 2 != 0)
            {
                MessageBox.Show("Broj kotača mora biti paran!", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                txtBrojKotaca.Focus();
                return false;
            }

            return true;
        }

        private string GetKategorija(int brojKotaca)
        {
            if (brojKotaca == 2)
            {
                return "Motocikl";
            }
            else if (brojKotaca == 4)
            {
                return "Automobil";
            }
            else
            {
                return "Kamion";
            }
        }

    }
}

