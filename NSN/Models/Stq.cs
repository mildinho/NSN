using System;
using System.ComponentModel.DataAnnotations;

namespace NSN.Models
{
    public class Stq
    {
        [Display(Name = "Referência")]
        public string refx { get; set; }
        [Display(Name = "Cd. Bar. Interno")]
        public string cdbar { get; set; }
        [Display(Name = "Cd. Bar. Produto")]
        public string cdbar2 { get; set; }
        public string cdnum { get; set; }
        [Display(Name = "Descrição")]
        public string descr { get; set; }
        [Display(Name = "Nr. Original")]
        public string nrorig { get; set; }
        [Display(Name = "Conversão")] 
        public string conversao { get; set; }
        [Display(Name = "UN.")]
        public string unid { get; set; }
        public long pmedio { get; set; }
        public long pultrep { get; set; }
        public long ptabela1 { get; set; }
        public long ptabela2 { get; set; }
        public long percipi { get; set; }
        [Display(Name = "Sit. Trib.")]
        public string sittrib { get; set; }
        public int aliqicms { get; set; }
        public long pvatacado { get; set; }
        public long pvendaant { get; set; }
        public long pvenda { get; set; }
        public long pvendafut { get; set; }
        public long pofertant { get; set; }
        public long pofert { get; set; }
        public long pofertfut { get; set; }
        public string ultrepoc { get; set; }
        public int sdcomp { get; set; }
        public int saldo { get; set; }
        public int reserva { get; set; }
        public int emax { get; set; }
        public int emin { get; set; }
        [Display(Name = "Local")]
        public string localx { get; set; }
        public string nlocal { get; set; }
        [Display(Name = "Qt. Emb.")]
        public int qemb { get; set; }
        [Display(Name = "Peso Liq.")]
        public int pesoliq { get; set; }
        public DateTime dtconf { get; set; }
        public string numnf { get; set; }
        public int meta1 { get; set; }
        public int meta2 { get; set; }
        public int meta3 { get; set; }
        public int meta4 { get; set; }
        public int meta5 { get; set; }
        public int meta6 { get; set; }
        public int meta7 { get; set; }
        public int meta8 { get; set; }
        public int meta9 { get; set; }
        public int meta10 { get; set; }
        public int meta11 { get; set; }
        public int meta12 { get; set; }
        public long pmedioant { get; set; }
        public long pultrepant { get; set; }
        public int saldoant { get; set; }
        public string ulrepocant { get; set; }
        public int sdcontag1 { get; set; }
        public int sdcontag2 { get; set; }
        public string indisp { get; set; }
        public string indispfut { get; set; }
        public string promoqt { get; set; }
        [Display(Name = "Larg.")]
        public long larg { get; set; }
        [Display(Name = "Alt.")]
        public long alt { get; set; }
        [Display(Name = "Compr.")]
        public long compr { get; set; }
        public long cubi { get; set; }
        [Display(Name = "Mult. Venda")]
        public int multi { get; set; }
        public int vmax { get; set; }
        public int minqt { get; set; }
        public long valorprom { get; set; }
        public DateTime dtctg { get; set; }
        public string rpctg { get; set; }
        public long rankq { get; set; }
        public long ranql { get; set; }
        public int pkmin { get; set; }
        public int pkmax { get; set; }
        public int pksd { get; set; }
        public string pktam { get; set; }
        public string bloq { get; set; }
        public DateTime blodt { get; set; }
        public string blohi { get; set; }
        public string blohf { get; set; }
        public int minqt2 { get; set; }
        public long valorprom2 { get; set; }
        public string grupo { get; set; }
        public string subgrupo { get; set; }
        public long p_desc_nor { get; set; }
        public long p_desc_esp { get; set; }
        public DateTime dt_val_des { get; set; }
        public int desc_comp { get; set; }
        public string ref2 { get; set; }
        [Display(Name = "Mult. Compra")]
        public int multcomp { get; set; }
        [Display(Name = "Clasif. Fiscal")]
        public string classfisc { get; set; }
        public int flagcampo { get; set; }
        public int flagpreco { get; set; }
        public DateTime dtinic { get; set; }
        public long emax_exced { get; set; }
        public string bloqcompra { get; set; }
        [Display(Name = "Curva Forn.")]
        public string curvaabc { get; set; }
        public long porcentabc { get; set; }
        public DateTime dtcadastro { get; set; }
        public int utembforn { get; set; }
        public int embfornvol { get; set; }
        public string conferent1 { get; set; }
        public string conferent2 { get; set; }
        public string digitador1 { get; set; }
        public string digitador2 { get; set; }
        public int transito { get; set; }
        public string nrfabr { get; set; }
        public string grupostq { get; set; }
        public string subgstq { get; set; }
        public long sttabcmp { get; set; }
        public int aliqicms2 { get; set; }
        public int aliqicms3 { get; set; }
        public int descofert { get; set; }
        public string fornorig { get; set; }
        public string fornultrep { get; set; }
        public long sttabcmpfu { get; set; }
        public long preco_dia { get; set; }
        public string disponivel { get; set; }
        public DateTime data399 { get; set; }
        public string tipopec { get; set; }
        public string nome_img { get; set; }
        [Display(Name = "Parceiro")]
        public string idparceiro { get; set; }
        [Display(Name = "Forn. Origem")]
        public string origidparc { get; set; }
        public string idultrep { get; set; }
        public long pfiscal { get; set; }
        public int mediamani { get; set; }
        public int mmani1 { get; set; }
        public int mmani2 { get; set; }
        public int mmani3 { get; set; }
        public int precolib { get; set; }
        public int precolib2 { get; set; }
        [Display(Name = "Revista")]
        public string revista { get; set; }
        public string cobrafrete { get; set; }
        public DateTime datalib { get; set; }
        public long pultrepfre { get; set; }
        public long adc_pis { get; set; }
        public long adc_cofins { get; set; }
        public long suframa { get; set; }
        public string importado { get; set; }
        public DateTime dtvalidade { get; set; }
        public int precolib3 { get; set; }
        public DateTime dtfinal { get; set; }
        public string bloqtransp { get; set; }
        [Display(Name = "Curva Grupo")] 
        public string curvagrupo { get; set; }
        public string prcerrado { get; set; }
        public long pultreps { get; set; }
        public long pmedios { get; set; }
        public string quembloq { get; set; }
        public string filial { get; set; }
        [Display(Name = "Comprador")] 
        public string comp { get; set; }

    }
}
