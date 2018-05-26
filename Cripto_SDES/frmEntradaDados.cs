using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cripto_SDES
{
    public partial class frmEntradaDados : Form
    {
        private string sChaveP8_K1;
        private string sChaveP8_K2;

        public frmEntradaDados()
        {
            InitializeComponent();
        }

        private void btnCrip_Click(object sender, EventArgs e)
        {
            if (!criticaChaveOK()) return;
            string sChave = stringParaBinario(txtChave.Text);
            sChave = "0" + sChave; // para compensar a extração da substring iniciando do 1 em vez de 0
            // cria Chave P10 ==> 3 5 2 7 4 10 1 9 8 6
            string sChaveP10 = sChave.Substring(3, 1)+ sChave.Substring(5, 1)+ sChave.Substring(2, 1)+ sChave.Substring(7, 1)+ sChave.Substring(4, 1)+
                              sChave.Substring(10, 1)+ sChave.Substring(1, 1)+ sChave.Substring(9, 1)+ sChave.Substring(8, 1)+ sChave.Substring(6, 1);
            // cria LS1
            string sLS1 = sChave.Substring(1, 4) + sChave.Substring(0, 1) + sChave.Substring(6, 4) + sChave.Substring(5, 1);
            sLS1 = "0" + sLS1;    // para compensar a extração da substring iniciando do 1 em vez de 0
            // cria subchave P8_K1 ==> 6 3 7 4 8 5 10 9
            string sChaveP8_K1 = sLS1.Substring(6, 1) + sLS1.Substring(3, 1) + sLS1.Substring(7, 1) + sLS1.Substring(4, 1)+
                                 sLS1.Substring(8, 1) + sLS1.Substring(5, 1) + sLS1.Substring(10, 1) + sLS1.Substring(9, 1);
            // cria LS2
            string sLS2 = sLS1.Substring(3, 3) + sLS1.Substring(1, 2) + sLS1.Substring(8, 3) + sLS1.Substring(6, 2);
            sLS2 = "0" + sLS2;    // para compensar a extração da substring iniciando do 1 em vez de 0
            // cria subchave P8_K2 ==> 6 3 7 4 8 5 10 9
            string sChaveP8_K2 = sLS2.Substring(6, 1) + sLS2.Substring(3, 1) + sLS2.Substring(7, 1) + sLS2.Substring(4, 1) +
                                 sLS2.Substring(8, 1) + sLS2.Substring(5, 1) + sLS2.Substring(10, 1) + sLS2.Substring(9, 1);
            // PEND: VER COMO TRATAR CADA LETRA DO TEXTO EM LOOP
            string sTexto = "0"+txtTexto.Text;
            // cria IP  ==> 2 3 6 1 4 8 5 7
            string sIP = sTexto.Substring(2, 1) + sTexto.Substring(3, 1) + sTexto.Substring(6, 1) + sTexto.Substring(1, 1) +
                         sTexto.Substring(4, 1) + sTexto.Substring(8, 1) + sTexto.Substring(5, 1) + sTexto.Substring(7, 1);
            // cria E/P ==> 4 1 2 3 2 3 4 1 (lado direito de sIP, 4 últimos bits)
            sIP = "0" + sIP; // para compensar a extração da substring iniciando do 1 em vez de 0
            string sIPDir = sIP.Substring(5, 4);
            sIPDir = "0" + sIPDir; // para compensar a extração da substring iniciando do 1 em vez de 0
            string sE_P = sIPDir.Substring(4, 1) + sIPDir.Substring(1, 1) + sIPDir.Substring(2, 1) + sIPDir.Substring(3, 1) +
                          sIPDir.Substring(2, 1) + sIPDir.Substring(3, 1) + sIPDir.Substring(4, 1) + sIPDir.Substring(1, 1);
            // Ou-exclusivo de sChaveP8_K1 e sE_P
            string sResult1DoOuExclusivo = "0"+ouExclusivoDeExpressao(sChaveP8_K1, sE_P);
            // Extrai linha/coluna de sResult1DoOuExclusivo
            string sLinColExtraidaDeResultOuExclusivo = sResult1DoOuExclusivo.Substring(7, 1) + sResult1DoOuExclusivo.Substring(4, 1) +
                                                        sResult1DoOuExclusivo.Substring(6, 1) + sResult1DoOuExclusivo.Substring(5, 1);
            // cria sChaveP4_K1 (lado esquerdo de sIP, 4 primeiros bits)
            string sIPEsq = sIP.Substring(1, 4);
            string sChaveP4_K1 = ouExclusivoDeExpressao(sLinColExtraidaDeResultOuExclusivo, sIPEsq);
            // cria saída
            string saida = sChaveP4_K1 + sIPDir;
            // inverte a saída
            string sw = sIPDir + sChaveP4_K1;
            // recalcula sE_P utilizando o lado direito de sw -> sChaveP4_K1
            sChaveP4_K1 = "0" + sChaveP4_K1; // para compensar a extração da substring iniciando do 1 em vez de 0
            sE_P = sChaveP4_K1.Substring(4, 1) + sChaveP4_K1.Substring(1, 1) + sChaveP4_K1.Substring(2, 1) + sChaveP4_K1.Substring(3, 1) +
                   sChaveP4_K1.Substring(2, 1) + sChaveP4_K1.Substring(3, 1) + sChaveP4_K1.Substring(4, 1) + sChaveP4_K1.Substring(1, 1);
            // Ou-exclusivo de sChaveP8_K2 e sE_P
            string sResult2DoOuExclusivo = ouExclusivoDeExpressao(sChaveP8_K2, sE_P);
            // cria sChaveP4_K2
            string saidaEsq = saida.Substring(0, 4);
            string saidaDir = saida.Substring(5, 4);
            string sChaveP4_K2 = ouExclusivoDeExpressao(saidaEsq, saidaDir);
            // atribui nova saida
            saida = sChaveP4_K2 + saida.Substring(0, 4);
            saida = "0" + saida; // para compensar a extração da substring iniciando do 1 em vez de 0
            //cria IP-1
            string sIP_1 = saida.Substring(5, 2) + saida.Substring(3, 2) + 
                saida.Substring(2, 1) + saida.Substring(1, 1) + saida.Substring(8, 1) + saida.Substring(7, 1);
            // escreve resultado
            txtResultado.Text = sIP_1;            
        }

        private void btnDecrip_Click(object sender, EventArgs e)
        {
            if (!criticaChaveOK()) return;
            string sChave = stringParaBinario(txtChave.Text);
            sChave = calculaSubChaves8Bits(sChave);
            string sTexto = "0" + txtTexto.Text;
            // cria IP  ==> 2 6 3 1 4 8 5 7   01001101 -> 11000110
            string sIP = sTexto.Substring(2, 1) + sTexto.Substring(6, 1) + sTexto.Substring(3, 1) + sTexto.Substring(1, 1) +
                         sTexto.Substring(4, 1) + sTexto.Substring(8, 1) + sTexto.Substring(5, 1) + sTexto.Substring(7, 1);
            // cria E/P ==> 4 1 2 3 2 3 4 1 (lado direito de sIP, 4 últimos bits)
            sIP = "0" + sIP; // para compensar a extração da substring iniciando do 1 em vez de 0
            string sIPDir = sIP.Substring(5, 4);
            sIPDir = "0" + sIPDir; // para compensar a extração da substring iniciando do 1 em vez de 0
            string sE_P = sIPDir.Substring(4, 1) + sIPDir.Substring(1, 1) + sIPDir.Substring(2, 1) + sIPDir.Substring(3, 1) +
                          sIPDir.Substring(2, 1) + sIPDir.Substring(3, 1) + sIPDir.Substring(4, 1) + sIPDir.Substring(1, 1);
            // Ou-exclusivo de sChaveP8_K2 e sE_P
            string sResult2DoOuExclusivo = "0" + ouExclusivoDeExpressao(sChaveP8_K2, sE_P);
            // Extrai linha/coluna de sResult2DoOuExclusivo
            string sLinColExtraidaDeResultOuExclusivo = sResult2DoOuExclusivo.Substring(7, 1) + sResult2DoOuExclusivo.Substring(4, 1) +
                                                        sResult2DoOuExclusivo.Substring(6, 1) + sResult2DoOuExclusivo.Substring(5, 1);
            // cria sChaveP4_K2 (lado esquerdo de sIP, 4 primeiros bits)
            string sIPEsq = sIP.Substring(1, 4);
            sIPDir = sIPDir.Substring(1, 4); // restaura sIPDir antes
            string sChaveP4_K2 = ouExclusivoDeExpressao(sIPDir, sIPEsq);
            // cria saída
            string saida = sChaveP4_K2 + sIPDir;
            // inverte a saída
            string sw = sIPDir + sChaveP4_K2;
            // recalcula sE_P utilizando sw
            sw = "0" + sw; // para compensar a extração da substring iniciando do 1 em vez de 0
            sE_P = sw.Substring(4, 1) + sw.Substring(1, 1) + sw.Substring(2, 1) + sw.Substring(3, 1) +
                   sw.Substring(2, 1) + sw.Substring(3, 1) + sw.Substring(4, 1) + sw.Substring(1, 1);
            // Ou-exclusivo de sChaveP8_K1 e sE_P
            string sResult1DoOuExclusivo = ouExclusivoDeExpressao(sChaveP8_K1, sE_P);
            // cria sChaveP4_K1
            saida = "0" + saida; // para compensar a extração da substring iniciando do 1 em vez de 0
            string saidaEsq = saida.Substring(4, 1) + saida.Substring(1, 1) + saida.Substring(2, 1) + saida.Substring(3, 1);
            string saidaDir = saida.Substring(5, 4);
            string sChaveP4_K1 = ouExclusivoDeExpressao(saidaEsq, saidaDir);
            // atribui nova saida
            saida = sChaveP4_K1 + saida.Substring(1, 4);
            saida = "0" + saida; // para compensar a extração da substring iniciando do 1 em vez de 0
            // cria IP-1
            string sIP_1 = saida.Substring(4, 1) + saida.Substring(1, 1) + saida.Substring(3, 1) + saida.Substring(5, 1) +
                           saida.Substring(7, 1) + saida.Substring(2, 1) + saida.Substring(8, 1) + saida.Substring(6, 1);
            // escreve resultado
            txtResultado.Text = sIP_1;
        }

        private bool criticaChaveOK()
        {
            if (txtChave.Text.Length != 10)
            {
                MessageBox.Show("Chave deve conter 10 caracteres !", "Crip/Decrip",
                    MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return false;
            }
            return true;
        }

        private string stringParaBinario(string s)
        {
            string ret = "";
            string chaveCompletaEmBinario = "";

            foreach (char c in s)
            {
                int asc = (int)c; // código numerico do caractere. Ex: s => 115 
                // Concatena a representação string dos 
                // números binários separados por espaço.
                chaveCompletaEmBinario += Convert.ToString(asc, 2) + " "; // 0110101 1100101...
                int soma = binarioParaInteiro(Convert.ToString(asc, 2)); // retorna 0 ou 1
                ret += seleciona(soma); // Ex: 0110010011
                //MessageBox.Show("Valor da letra: " + soma, "Cálculo do valor da letra da Chave",
                //MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            //MessageBox.Show("Resultado: " + chaveCompletaEmBinario + ". Retorno: " + ret, "Transformação de Chave para binário",
            //MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            return (ret);
        }
        private string seleciona(int n)
        {
            return ((n % 2) == 0 ? "0":"1");
        }

        private string calculaSubChaves8Bits(string sChave)
        {
            sChave = "0" + sChave; // para compensar a extração da substring iniciando do 1 em vez de 0
            // cria Chave P10 ==> 3 5 2 7 4 10 1 9 8 6
            string sChaveP10 = sChave.Substring(3, 1) + sChave.Substring(5, 1) + sChave.Substring(2, 1) + sChave.Substring(7, 1) + sChave.Substring(4, 1) +
                              sChave.Substring(10, 1) + sChave.Substring(1, 1) + sChave.Substring(9, 1) + sChave.Substring(8, 1) + sChave.Substring(6, 1);
            // cria LS1
            string sLS1 = sChave.Substring(1, 4) + sChave.Substring(0, 1) + sChave.Substring(6, 4) + sChave.Substring(5, 1);
            sLS1 = "0" + sLS1;    // para compensar a extração da substring iniciando do 1 em vez de 0
            // cria subchave P8_K1 ==> 6 3 7 4 8 5 10 9
            sChaveP8_K1 = sLS1.Substring(6, 1) + sLS1.Substring(3, 1) + sLS1.Substring(7, 1) + sLS1.Substring(4, 1) +
                          sLS1.Substring(8, 1) + sLS1.Substring(5, 1) + sLS1.Substring(10, 1) + sLS1.Substring(9, 1);
            // cria LS2
            string sLS2 = sLS1.Substring(3, 3) + sLS1.Substring(1, 2) + sLS1.Substring(8, 3) + sLS1.Substring(6, 2);
            sLS2 = "0" + sLS2;    // para compensar a extração da substring iniciando do 1 em vez de 0
            // cria subchave P8_K2 ==> 6 3 7 4 8 5 10 9
            sChaveP8_K2 = sLS2.Substring(6, 1) + sLS2.Substring(3, 1) + sLS2.Substring(7, 1) + sLS2.Substring(4, 1) +
                          sLS2.Substring(8, 1) + sLS2.Substring(5, 1) + sLS2.Substring(10, 1) + sLS2.Substring(9, 1);
            return sChave;
        }

        private void binarioParaString(string bin)
        {
            // Separa os números binários e joga o resultado
            // num array de strings.
            string[] strBin = bin.Trim().Split(' ');
            string rec = "";

            foreach (string ele in strBin)
            {
                // Converte a representação string do número
                // num caractere.
                char car = (char)Convert.ToInt32(ele, 2);
                // Concatena os caracteres.
                rec += car;
            }
            MessageBox.Show("Resultado: " + rec, "Transformação de binário para Chave",
            MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        private int binarioParaDecimal(string valorBinario)
        {
            int expoente = 0;
            int numero;
            int soma = 0;
            for (int i = 0; i < valorBinario.Length; i++)
            {
                //pega dígito por dígito do número digitado
                numero = Convert.ToInt32(valorBinario.Substring(i, 1));
                //multiplica o dígito por 2 elevado ao expoente, e armazena o resultado em soma
                soma += numero * (int)Math.Pow(2, expoente);
                // incrementa o expoente
                expoente++;
            }
            return soma;
        }

        private int binarioParaInteiro(string binario)
        {
            int inteiro = Convert.ToInt16(binario, 2); // 2 é a base para conversão
            return (inteiro);
        }
        
        private string ouExclusivoDeExpressao(string exp1, string exp2)
        {
            string sRet = "";
            for (int i = 0; i < exp1.Length; i++)
            {
                sRet += ouExclusivo(exp1.Substring(i, 1), exp2.Substring(i, 1));
            }
            return sRet;
        }
        
        private string ouExclusivo(string bit1, string bit2)
        {
            return (bit1 == bit2 ? "0": "1");
        }
    }
}
