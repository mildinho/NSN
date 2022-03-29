using NSN.Biblioteca;
using NSN.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NSN.Repository
{
    public class StqRepository : Interface.IStq
    {
        public Conexao ConnFur = new Conexao(ConexaoName.Furacao);

        public List<Stq> Pesquisa_Referencia_Item(string creferencia,string cfilial=null)
        {
            string csql = @"select 
                            sg.refx        , 
                            sg.cdbar       , 
                            sg.cdbar2      , 
                            sg.cdnum       , 
                            sg.descr       , 
                            sg.nrorig      , 
                            sg.conversao   , 
                            sg.unid        , 
                            sg.pmedio      , 
                            sg.pultrep     , 
                            sg.ptabela1    , 
                            sg.ptabela2    , 
                            sg.percipi     , 
                            sg.sittrib     , 
                            sg.aliqicms    , 
                            sg.pvatacado   , 
                            sg.pvendaant   , 
                            sg.pvenda      , 
                            sg.pvendafut   , 
                            sg.pofertant   , 
                            sg.pofert      , 
                            sg.pofertfut   , 
                            sg.ultrepoc    , 
                            sg.sdcomp      , 
                            sg.saldo       , 
                            sg.reserva     , 
                            sg.emax        , 
                            sg.emin        , 
                            substr(sg.localx,1,2)||'.'||substr(sg.localx,5,1)||'.'||substr(sg.localx,3,2) localx  , 
                            sg.nlocal      , 
                            sg.qemb        , 
                            sg.pesoliq     , 
                            sg.dtconf      , 
                            sg.numnf       , 
                            sg.meta1       , 
                            sg.meta2       , 
                            sg.meta3       , 
                            sg.meta4       , 
                            sg.meta5       , 
                            sg.meta6       , 
                            sg.meta7       , 
                            sg.meta8       , 
                            sg.meta9       , 
                            sg.meta10      , 
                            sg.meta11      , 
                            sg.meta12      , 
                            sg.pmedioant   , 
                            sg.pultrepant  , 
                            sg.saldoant    , 
                            sg.ulrepocant  , 
                            sg.sdcontag1   , 
                            sg.sdcontag2   , 
                            sg.indisp      , 
                            sg.indispfut   , 
                            sg.promoqt     , 
                            sg.larg        , 
                            sg.alt         , 
                            sg.compr       , 
                            sg.cubi        , 
                            sg.multi       , 
                            sg.vmax        , 
                            sg.minqt       , 
                            sg.valorprom   , 
                            sg.dtctg       , 
                            sg.rpctg       , 
                            sg.rankq       , 
                            sg.ranql       , 
                            sg.pkmin       , 
                            sg.pkmax       , 
                            sg.pksd        , 
                            sg.pktam       , 
                            sg.bloq        , 
                            sg.blodt       , 
                            sg.blohi       , 
                            sg.blohf       , 
                            sg.minqt2      , 
                            sg.valorprom2  , 
                            sg.grupo       , 
                            sg.subgrupo    , 
                            sg.p_desc_nor  , 
                            sg.p_desc_esp  , 
                            sg.dt_val_des  , 
                            sg.desc_comp   , 
                            sg.ref2        , 
                            sg.multcomp    , 
                            sg.classfisc   , 
                            sg.flagcampo   , 
                            sg.flagpreco   , 
                            sg.dtinic      , 
                            sg.emax_exced  , 
                            sg.bloqcompra  , 
                            sg.curvaabc    , 
                            sg.porcentabc  , 
                            sg.dtcadastro  , 
                            sg.utembforn   , 
                            sg.embfornvol  , 
                            sg.conferent1  , 
                            sg.conferent2  , 
                            sg.digitador1  , 
                            sg.digitador2  , 
                            sg.transito    , 
                            sg.nrfabr      , 
                            sg.grupostq    , 
                            sg.subgstq     , 
                            sg.sttabcmp    , 
                            sg.aliqicms2   , 
                            sg.aliqicms3   , 
                            sg.descofert   , 
                            sg.fornorig    , 
                            sg.fornultrep  , 
                            sg.sttabcmpfu  , 
                            sg.preco_dia   , 
                            sg.disponivel  , 
                            sg.data399     , 
                            sg.tipopec     , 
                            sg.nome_img    , 
                            sg.idparceiro  , 
                            sg.origidparc  , 
                            sg.idultrep    , 
                            sg.pfiscal     , 
                            sg.mediamani   , 
                            sg.mmani1      , 
                            sg.mmani2      , 
                            sg.mmani3      , 
                            sg.precolib    , 
                            sg.precolib2   , 
                            sg.revista     , 
                            sg.cobrafrete  , 
                            sg.datalib     , 
                            sg.pultrepfre  , 
                            sg.adc_pis     , 
                            sg.adc_cofins  , 
                            sg.suframa     , 
                            sg.importado   , 
                            sg.dtvalidade  , 
                            sg.precolib3   , 
                            sg.dtfinal     , 
                            sg.bloqtransp  , 
                            sg.curvagrupo  , 
                            sg.prcerrado   , 
                            sg.pultreps    , 
                            sg.pmedios     , 
                            sg.quembloq    ,
                            sg.filial      ,
                            round(case when sg.pofert > 0 then (sg.pvenda - sg.pofert) * 100 / sg.pvenda  else 0 end,2) percof,
                            fg.comprador comp,
                            fg.desc_nor2, 
                            pg.polvdesc, 
                            pg.polvmarg 
                            from vw_stq_geral sg 
                            inner join vw_fornec_geral fg on fg.filial = sg.filial and fg.idparceiro = sg.idparceiro
                            inner join vw_policomp_geral pg on pg.filial = sg.filial and pg.idparceiro = sg.idparceiro
                            where sg.refx = :cRefx";

            var param = ConnFur.DefineParametros();
            List<Stq> retorno =  new List<Stq>();

            if (ConnFur.AbreConexao())
            {
                try
                {
                    param.Add("cRefx", creferencia.ToUpper());

                    if (cfilial != null)
                    {
                        csql += " and sg.filial = :cFilial";
                        param.Add("cFilial", cfilial.ToUpper());
                    }

                    retorno = ConnFur.SQLSelect<Stq>(csql, param).ToList();
                }
                finally
                {
                    ConnFur.FechaConexao();
                }
            }
            return retorno;
        }

        public List<Stq> Pesquisa_Referencia_Lista(string cReferencia)
        {
            throw new NotImplementedException();
        }
    }
}
