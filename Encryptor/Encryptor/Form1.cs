using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Encryptor
{
    public partial class Form1 : Form
    {
        /// <summary>
        /// Funktionen för samtliga listboxes och knappar.
        /// </summary>
        Samling CipherSave;
        ReversalCipher reversal;
        CeasarChipher caesar;
        List<Cipher> cipherlist = new List<Cipher>();
        OddAndEvenChipher oddEv;
        Rövarspråket sprak;


        

        public Form1()
        {
            InitializeComponent();
            StartCiphers();
            


        }
        /// <summary>
        /// Metod för att starta applikationen. Innehåller instansiering av objekt från klasserna.
        /// </summary>
        public void StartCiphers()
        {            
            CipherSave = new Samling();
            cipherlist = new List<Cipher>();
            reversal = new ReversalCipher("Reversal Cipher");
            caesar = new CeasarChipher(1, "Caesar Cipher");
            oddEv = new OddAndEvenChipher("OddAndEven Cipher");
            sprak = new Rövarspråket("Rövarspråket");


            
            listBox1.Items.Add(reversal);
            
            listBox1.Items.Add(caesar);
             
            listBox1.Items.Add(oddEv);
            listBox1.Items.Add(sprak);
        }

        /// <summary>
        /// Metod för uppdatering av listan. Innehåller bools för felhantering så att det inte går att klicka på knapparna för många gånger så att inte applikationen kraschar.
        /// </summary>
        public void UpdatedList()
        {
            listBox2.DataSource = null;
            listBox2.DataSource = CipherSave.Getlist();
            if (listBox2.Items.Count == 0)
            {
                RemoveButton.Enabled = false;
                Add.Enabled = true;
            }
        }

        /// <summary>
        /// Knappen för att enkryptera. Finns det ingen text i så går det ej att klicka på den(felhantering).
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonEncrpyt_Click(object sender, EventArgs e)
        {

            textBoxInput.Text = CipherSave.Encrypt(textBoxInput.Text);

            buttonEncrpyt.Enabled = false;
            buttonDecrpyt.Enabled = true;
            Add.Enabled = false;

            
        }


        /// <summary>
        /// Knapp för att dekryptera. Finns det inget valt från listan så går det inte att dekryptera(felhantering).
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonDecrpyt_Click(object sender, EventArgs e)
        {

            textBoxInput.Text = CipherSave.Decrypt(textBoxInput.Text);

            buttonDecrpyt.Enabled = false;
            buttonEncrpyt.Enabled = true;
            Add.Enabled = true;

           

 

        }

        /// <summary>
        /// Add knappen.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Add_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem == null)
            {
                MessageBox.Show("Välj Cipher!");

            }
            {
                Cipher add = (Cipher)listBox1.SelectedItem;
                CipherSave.AddCipher(add);
                cipherlist.Add(add);
                UpdatedList();

                buttonEncrpyt.Enabled = true;
                buttonDecrpyt.Enabled = false;
                RemoveButton.Enabled = true;
            }




        }


        /// <summary>
        /// Removeknappen, går ett att klicka ifall listan för valda ciphers är tom(felhantering).
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RemoveButton_Click(object sender, EventArgs e)
        {
            
            Cipher remove = (Cipher)listBox2.SelectedItem;

            
             if (buttonEncrpyt.Enabled == false)
             {
                textBoxInput.Text = CipherSave.Decrypt(textBoxInput.Text);
                CipherSave.RemoveCipher(remove);
                textBoxInput.Text = CipherSave.Encrypt(textBoxInput.Text);
                cipherlist.Remove(remove);


             }


            else
            {
                CipherSave.RemoveCipher(remove);
                cipherlist.Remove(remove);
               
                

            }
           
             
            UpdatedList();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
