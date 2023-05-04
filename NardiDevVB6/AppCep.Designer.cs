namespace NardiDevVB6
{
    partial class AppCep
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnPesquisa = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.dgCep = new System.Windows.Forms.DataGridView();
            this.cep = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.logradouro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.complemento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bairro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.localidade = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.uf = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ibge = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ddd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.siafi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.origem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblPesquisa = new System.Windows.Forms.Label();
            this.txtCep = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgCep)).BeginInit();
            this.SuspendLayout();
            // 
            // btnPesquisa
            // 
            this.btnPesquisa.Location = new System.Drawing.Point(482, 187);
            this.btnPesquisa.Name = "btnPesquisa";
            this.btnPesquisa.Size = new System.Drawing.Size(76, 23);
            this.btnPesquisa.TabIndex = 0;
            this.btnPesquisa.Text = "Pesquisa CEP";
            this.btnPesquisa.UseVisualStyleBackColor = true;
            this.btnPesquisa.Click += new System.EventHandler(this.btnPesquisa_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(76, 235);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(91, 31);
            this.btnRemove.TabIndex = 1;
            this.btnRemove.Text = "Limpar CEPs";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // dgCep
            // 
            this.dgCep.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgCep.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cep,
            this.logradouro,
            this.complemento,
            this.bairro,
            this.localidade,
            this.uf,
            this.ibge,
            this.gia,
            this.ddd,
            this.siafi,
            this.origem});
            this.dgCep.Location = new System.Drawing.Point(12, 12);
            this.dgCep.Name = "dgCep";
            this.dgCep.Size = new System.Drawing.Size(704, 150);
            this.dgCep.TabIndex = 2;
            // 
            // cep
            // 
            this.cep.HeaderText = "cep";
            this.cep.Name = "cep";
            this.cep.ReadOnly = true;
            // 
            // logradouro
            // 
            this.logradouro.HeaderText = "logradouro";
            this.logradouro.Name = "logradouro";
            this.logradouro.ReadOnly = true;
            // 
            // complemento
            // 
            this.complemento.HeaderText = "complemento";
            this.complemento.Name = "complemento";
            this.complemento.ReadOnly = true;
            // 
            // bairro
            // 
            this.bairro.HeaderText = "bairro";
            this.bairro.Name = "bairro";
            this.bairro.ReadOnly = true;
            // 
            // localidade
            // 
            this.localidade.HeaderText = "localidade";
            this.localidade.Name = "localidade";
            this.localidade.ReadOnly = true;
            // 
            // uf
            // 
            this.uf.HeaderText = "uf";
            this.uf.Name = "uf";
            this.uf.ReadOnly = true;
            // 
            // ibge
            // 
            this.ibge.HeaderText = "ibge";
            this.ibge.Name = "ibge";
            this.ibge.ReadOnly = true;
            // 
            // gia
            // 
            this.gia.HeaderText = "gia";
            this.gia.Name = "gia";
            this.gia.ReadOnly = true;
            // 
            // ddd
            // 
            this.ddd.HeaderText = "ddd";
            this.ddd.Name = "ddd";
            this.ddd.ReadOnly = true;
            // 
            // siafi
            // 
            this.siafi.HeaderText = "siafi";
            this.siafi.Name = "siafi";
            this.siafi.ReadOnly = true;
            // 
            // origem
            // 
            this.origem.HeaderText = "origem";
            this.origem.Name = "origem";
            this.origem.ReadOnly = true;
            // 
            // lblPesquisa
            // 
            this.lblPesquisa.AutoSize = true;
            this.lblPesquisa.Location = new System.Drawing.Point(194, 190);
            this.lblPesquisa.Name = "lblPesquisa";
            this.lblPesquisa.Size = new System.Drawing.Size(107, 13);
            this.lblPesquisa.TabIndex = 3;
            this.lblPesquisa.Text = "Digite CEP Pesquisa:";
            this.lblPesquisa.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.lblPesquisa.Click += new System.EventHandler(this.label1_Click);
            // 
            // txtCep
            // 
            this.txtCep.Location = new System.Drawing.Point(307, 187);
            this.txtCep.Name = "txtCep";
            this.txtCep.Size = new System.Drawing.Size(152, 20);
            this.txtCep.TabIndex = 4;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(728, 286);
            this.Controls.Add(this.txtCep);
            this.Controls.Add(this.lblPesquisa);
            this.Controls.Add(this.dgCep);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.btnPesquisa);
            this.Name = "Form1";
            this.Text = "Pesquisa ViaCep";
            ((System.ComponentModel.ISupportInitialize)(this.dgCep)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnPesquisa;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.DataGridView dgCep;
        private System.Windows.Forms.Label lblPesquisa;
        private System.Windows.Forms.TextBox txtCep;
        private System.Windows.Forms.DataGridViewTextBoxColumn cep;
        private System.Windows.Forms.DataGridViewTextBoxColumn logradouro;
        private System.Windows.Forms.DataGridViewTextBoxColumn complemento;
        private System.Windows.Forms.DataGridViewTextBoxColumn bairro;
        private System.Windows.Forms.DataGridViewTextBoxColumn localidade;
        private System.Windows.Forms.DataGridViewTextBoxColumn uf;
        private System.Windows.Forms.DataGridViewTextBoxColumn ibge;
        private System.Windows.Forms.DataGridViewTextBoxColumn gia;
        private System.Windows.Forms.DataGridViewTextBoxColumn ddd;
        private System.Windows.Forms.DataGridViewTextBoxColumn siafi;
        private System.Windows.Forms.DataGridViewTextBoxColumn origem;
    }
}

