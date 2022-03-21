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
                            refx        , 
                            cdbar       , 
                            cdbar2      , 
                            cdnum       , 
                            descr       , 
                            nrorig      , 
                            conversao   , 
                            unid        , 
                            pmedio      , 
                            pultrep     , 
                            ptabela1    , 
                            ptabela2    , 
                            percipi     , 
                            sittrib     , 
                            aliqicms    , 
                            pvatacado   , 
                            pvendaant   , 
                            pvenda      , 
                            pvendafut   , 
                            pofertant   , 
                            pofert      , 
                            pofertfut   , 
                            ultrepoc    , 
                            sdcomp      , 
                            saldo       , 
                            reserva     , 
                            emax        , 
                            emin        , 
                            substr(localx,1,2)||'.'||substr(localx,5,1)||'.'||substr(localx,3,2) localx  ,
                            nlocal      , 
                            qemb        , 
                            pesoliq     , 
                            dtconf      , 
                            numnf       , 
                            meta1       , 
                            meta2       , 
                            meta3       , 
                            meta4       , 
                            meta5       , 
                            meta6       , 
                            meta7       , 
                            meta8       , 
                            meta9       , 
                            meta10      , 
                            meta11      , 
                            meta12      , 
                            pmedioant   , 
                            pultrepant  , 
                            saldoant    , 
                            ulrepocant  , 
                            sdcontag1   , 
                            sdcontag2   , 
                            indisp      , 
                            indispfut   , 
                            promoqt     , 
                            larg        , 
                            alt         , 
                            compr       , 
                            cubi        , 
                            multi       , 
                            vmax        , 
                            minqt       , 
                            valorprom   , 
                            dtctg       , 
                            rpctg       , 
                            rankq       , 
                            ranql       , 
                            pkmin       , 
                            pkmax       , 
                            pksd        , 
                            pktam       , 
                            bloq        , 
                            blodt       , 
                            blohi       , 
                            blohf       , 
                            minqt2      , 
                            valorprom2  , 
                            grupo       , 
                            subgrupo    , 
                            p_desc_nor  , 
                            p_desc_esp  , 
                            dt_val_des  , 
                            desc_comp   , 
                            ref2        , 
                            multcomp    , 
                            classfisc   , 
                            flagcampo   , 
                            flagpreco   , 
                            dtinic      , 
                            emax_exced  , 
                            bloqcompra  , 
                            curvaabc    , 
                            porcentabc  , 
                            dtcadastro  , 
                            utembforn   , 
                            embfornvol  , 
                            conferent1  , 
                            conferent2  , 
                            digitador1  , 
                            digitador2  , 
                            transito    , 
                            nrfabr      , 
                            grupostq    , 
                            subgstq     , 
                            sttabcmp    , 
                            aliqicms2   , 
                            aliqicms3   , 
                            descofert   , 
                            fornorig    , 
                            fornultrep  , 
                            sttabcmpfu  , 
                            preco_dia   , 
                            disponivel  , 
                            data399     , 
                            tipopec     , 
                            nome_img    , 
                            idparceiro  , 
                            origidparc  , 
                            idultrep    , 
                            pfiscal     , 
                            mediamani   , 
                            mmani1      , 
                            mmani2      , 
                            mmani3      , 
                            precolib    , 
                            precolib2   , 
                            revista     , 
                            cobrafrete  , 
                            datalib     , 
                            pultrepfre  , 
                            adc_pis     , 
                            adc_cofins  , 
                            suframa     , 
                            importado   , 
                            dtvalidade  , 
                            precolib3   , 
                            dtfinal     , 
                            bloqtransp  , 
                            curvagrupo  , 
                            prcerrado   , 
                            pultreps    , 
                            pmedios     , 
                            quembloq    ,
                            filial      ,
                            (select comprador from vw_fornec_geral fg where fg.filial = sg.filial and fg.idparceiro = sg.idparceiro) comp
                            from vw_stq_geral sg where refx like :cRefx||'%'";

            var param = ConnFur.DefineParametros();
            List<Stq> retorno =  new List<Stq>();

            if (ConnFur.AbreConexao())
            {
                try
                {
                    param.Add("cRefx", creferencia);

                    if (cfilial != null)
                    {
                        csql += " and filial = :cFilial";
                        param.Add("cFilial", cfilial);
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
