using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using App01_ConsultarCEP.Servico;
using App01_ConsultarCEP.Servico.Modelo;

namespace App01_ConsultarCEP
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            btnBuscar.Clicked += BuscarCEP;
            
        }

        private void BuscarCEP(object sender, EventArgs args)
        {
            string cep = entCEP.Text.Trim();

            if (ValidarCEP(cep))
            {
                try
                {
                    Endereco end = ViaCepServico.BuscarEnderecoCEP(cep);

                    if (end != null)
                    {

                        lblResultado.Text = string.Format("Endereço: {0}, {1}, {2} \r\n{3} ", end.localidade, end.uf, end.logradouro, end.bairro);
                    }
                    else
                    {
                        DisplayAlert("ERRO", "CEP Inexistete", "OK");
                    }
                }
                catch(Exception e)
                {
                    DisplayAlert("ERRO CRÍTICO", e.Message, "OK");
                }
            }
        }

        private bool ValidarCEP(string cep)
        {
            if (cep.Length != 8)
            {
                DisplayAlert("Erro", "O CEP deverá ter 8 dígitos sem hifen", "OK - voltar");
                return false;
            }

            return true;
        }
    }
}
