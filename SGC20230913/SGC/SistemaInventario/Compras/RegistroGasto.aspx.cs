﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Data;
using System.Collections;
using System.Configuration;
using System.Web.Services;
using CapaNegocios;
using CapaEntidad;
using SistemaInventario.Clases;
using EasyCallback;
using Newtonsoft.Json;

namespace SistemaInventario.Compras
{
    public partial class RegistroGasto : System.Web.UI.Page
    {
        protected override void OnInit(EventArgs e)
        {
            CallbackManager.Register(F_Controles_Inicializar_NET);
            CallbackManager.Register(F_Buscar_Productos_NET);
            CallbackManager.Register(F_AgregarTemporal_NET);
            CallbackManager.Register(F_EliminarTemporal_NET);
            CallbackManager.Register(F_GrabarDocumento_NET);
            CallbackManager.Register(F_Nuevo_NET);
            CallbackManager.Register(F_Buscar_NET);
            CallbackManager.Register(F_AnularRegistro_Net);
            CallbackManager.Register(F_CargarGrillaVaciaConsultaArticulo_NET);
            CallbackManager.Register(F_EditarTemporal_NET);
            CallbackManager.Register(F_TipoCambio_NET);
        }

        private string _menu = "3000"; private string _opcion = "5";
        protected void Page_Load(object sender, EventArgs e)
        {
            String Menu = Request.QueryString["Mn"]; String Opcion = Request.QueryString["Op"];
            //if (Menu == null | (_menu != Menu | _opcion != Opcion) | Utilitarios.Menu.F_PermisoOpcion(_menu, _opcion) == false)
            //{
            //    Response.Redirect("../Maestros/TipoCambio.aspx");
            //    return;
            //}
            Utilitarios.Menu.ModificarAccesos((System.Web.UI.WebControls.Menu)Master.FindControl("NavigationMenu"), Convert.ToInt32((Session["CodUsuario"])));
            P_Inicializar_GrillaVacia_ConsultaArticulo();
            P_Inicializar_GrillaVacia_DetalleArticulo();
            P_Inicializar_GrillaVacia_ConsultaFactura();
            Session["datos"] = true;
        }

        public String F_Controles_Inicializar_NET(String arg)
        {
            String str_resultado = "";
            String str_mensaje_operacion = "";
            String str_ddl_moneda_html = "";
            String str_ddl_formapago_html = "";
            String str_ddl_TipoDocumento_html = "";
            String str_ddl_igv_html = "";
            String str_ddl_clasificacion_html = "";

            decimal TC = 0;
            int int_resultado_operacion = 0;

            Hashtable obj_parametros = null;

            try
            {
                obj_parametros = SistemaInventario.Clases.JsonSerializer.FromJson<Hashtable>(arg);

                P_Controles_Inicializar(obj_parametros, ref ddlFormaPago, ref ddlMoneda, ref ddlIgv,
                    ref ddlTipoDocumento, ref ddlClasificacion);
                P_Obtener_TipoCambio(obj_parametros, ref TC);


                str_ddl_formapago_html = Mod_Utilitario.F_GetHtmlForControl(ddlFormaPago);
                str_ddl_moneda_html = Mod_Utilitario.F_GetHtmlForControl(ddlMoneda);
                str_ddl_TipoDocumento_html = Mod_Utilitario.F_GetHtmlForControl(ddlTipoDocumento);
                str_ddl_clasificacion_html = Mod_Utilitario.F_GetHtmlForControl(ddlClasificacion);

                str_ddl_igv_html = Mod_Utilitario.F_GetHtmlForControl(ddlIgv);

                int_resultado_operacion = 1;
                str_mensaje_operacion = "";

            }
            catch (Exception ex)
            {

                str_mensaje_operacion = "Ha ocurrido el siguiente error: " + ex.Message;
                int_resultado_operacion = 0;

            }

            str_resultado =
                Convert.ToString(int_resultado_operacion)
                + "~" +
                str_mensaje_operacion
                + "~" +
                str_ddl_formapago_html
                 + "~" +
                str_ddl_moneda_html
                   + "~" +
                TC.ToString()
                  + "~" +
                str_ddl_igv_html
                  + "~" +
                str_ddl_TipoDocumento_html
                  + "~" +
                str_ddl_clasificacion_html;

            return str_resultado;

        }

        public String F_Buscar_Productos_NET(String arg)
        {
            String str_resultado = "";
            String str_mensaje_operacion = "";
            String str_grvConsultaArticulo_html = "";
            int int_resultado_operacion = 0;

            Hashtable obj_parametros = null;

            try
            {
                obj_parametros = SistemaInventario.Clases.JsonSerializer.FromJson<Hashtable>(arg);

                //P_Cargar_Grilla(obj_parametros, ref grvConsultaArticulo);

                //str_grvConsultaArticulo_html = Mod_Utilitario.F_GetHtmlForControl(grvConsultaArticulo);


                int_resultado_operacion = 1;
                str_mensaje_operacion = "";

            }
            catch (Exception ex)
            {

                str_mensaje_operacion = "Ha ocurrido el siguiente error: " + ex.Message;
                int_resultado_operacion = 0;

            }

            str_resultado =
                Convert.ToString(int_resultado_operacion)
                + "~" +
                str_mensaje_operacion
                + "~" +
                str_grvConsultaArticulo_html;

            return str_resultado;

        }

        public String F_AgregarTemporal_NET(String arg)
        {
            String str_resultado = "";
            String str_mensaje_operacion = "";
            String str_grvDetalleArticulo_html = "";
            int int_resultado_operacion = 0;
            int Codigo = 0;
            Decimal Dscto = 0;
            Decimal Total = 0;
            Decimal SubTotal = 0;
            Decimal Igv = 0;
            String MsgError = "";
            Hashtable obj_parametros = null;

            try
            {
                obj_parametros = SistemaInventario.Clases.JsonSerializer.FromJson<Hashtable>(arg);
                P_AgregarTemporal(obj_parametros, ref Codigo, ref MsgError);
                //P_CargarGrillaTemporal(obj_parametros, Codigo, ref grvDetalleArticulo, ref SubTotal, ref Igv, ref Total, ref Dscto);
                //str_grvDetalleArticulo_html = Mod_Utilitario.F_GetHtmlForControl(grvDetalleArticulo);

                int_resultado_operacion = 1;
                str_mensaje_operacion = "";

            }
            catch (Exception ex)
            {

                str_mensaje_operacion = "Ha ocurrido el siguiente error: " + ex.Message;
                int_resultado_operacion = 0;

            }

            str_resultado =
                Convert.ToString(int_resultado_operacion)
                + "~" +
                str_mensaje_operacion
                + "~" +
                MsgError
                + "~" +
                Codigo.ToString()
                + "~" +
                str_grvDetalleArticulo_html
                 + "~" +
                Math.Round(Total, 2).ToString()
                + "~" +
                Math.Round(Igv, 2).ToString()
                 + "~" +
                Math.Round(SubTotal, 2).ToString()
                 + "~" +
                Math.Round(Dscto, 2).ToString();

            return str_resultado;

        }

        public String F_EliminarTemporal_NET(String arg)
        {
            String str_resultado = "";
            String str_mensaje_operacion = "";
            String str_grvDetalleArticulo_html = "";
            int int_resultado_operacion = 0;
            int Codigo = 0;
            Decimal Total = 0;
            Decimal SubTotal = 0;
            Decimal Igv = 0;
            Decimal Dscto = 0;
            String MsgError = "";
            Hashtable obj_parametros = null;

            try
            {
                obj_parametros = SistemaInventario.Clases.JsonSerializer.FromJson<Hashtable>(arg);
                P_EliminarTemporal(obj_parametros, ref MsgError);
                Codigo = Convert.ToInt32(obj_parametros["Filtro_CodigoTemporal"]);
                //P_CargarGrillaTemporal(obj_parametros, Codigo, ref grvDetalleArticulo, ref SubTotal, ref Igv, ref Total, ref Dscto);
                //str_grvDetalleArticulo_html = Mod_Utilitario.F_GetHtmlForControl(grvDetalleArticulo);

                int_resultado_operacion = 1;
                str_mensaje_operacion = "";

            }
            catch (Exception ex)
            {

                str_mensaje_operacion = "Ha ocurrido el siguiente error: " + ex.Message;
                int_resultado_operacion = 0;

            }

            str_resultado =
                Convert.ToString(int_resultado_operacion)
                + "~" +
                str_mensaje_operacion
                + "~" +
                MsgError
                + "~" +
                Codigo.ToString()
                + "~" +
                str_grvDetalleArticulo_html
                 + "~" +
               Math.Round(Total, 2).ToString()
                + "~" +
                Math.Round(Igv, 2).ToString()
                 + "~" +
                Math.Round(SubTotal, 2).ToString()
                 + "~" +
                Math.Round(Dscto, 2).ToString();

            return str_resultado;

        }

        public String F_GrabarDocumento_NET(String arg)
        {
            String str_resultado = "";
            String str_mensaje_operacion = "";
            String str_numerofactura = "";
            int int_resultado_operacion = 0;
            int Codigo = 0;
            String MsgError = "";
            Hashtable obj_parametros = null;

            try
            {
                obj_parametros = SistemaInventario.Clases.JsonSerializer.FromJson<Hashtable>(arg);
                P_GrabarDocumento(obj_parametros, ref MsgError, ref Codigo);

                int_resultado_operacion = 1;
                str_mensaje_operacion = MsgError;
            }
            catch (Exception ex)
            {
                str_mensaje_operacion = "Ha ocurrido el siguiente error: " + ex.Message;
                int_resultado_operacion = 0;
            }

            str_resultado =
                Convert.ToString(int_resultado_operacion)
                + "~" +
                str_mensaje_operacion
                + "~" +
                Codigo.ToString()
                + "~" +
                str_numerofactura;

            return str_resultado;
        }

        public String F_Nuevo_NET(String arg)
        {
            String str_resultado = "";
            String str_mensaje_operacion = "";
            String str_numerofactura = "";
            String str_grvDetalleArticulo_html = "";
            int int_resultado_operacion = 0;
            int Codigo = 0;

            String MsgError = "";
            Hashtable obj_parametros = null;

            try
            {
                obj_parametros = SistemaInventario.Clases.JsonSerializer.FromJson<Hashtable>(arg);
                P_LlenarGrillaVacia_Detalle();
                //str_grvDetalleArticulo_html = Mod_Utilitario.F_GetHtmlForControl(grvDetalleArticulo);
                int_resultado_operacion = 1;
                str_mensaje_operacion = MsgError;

            }
            catch (Exception ex)
            {

                str_mensaje_operacion = "Ha ocurrido el siguiente error: " + ex.Message;
                int_resultado_operacion = 0;

            }

            str_resultado =
                Convert.ToString(int_resultado_operacion)
                + "~" +
                str_mensaje_operacion
                + "~" +
                str_grvDetalleArticulo_html
                + "~" +
                str_numerofactura;


            return str_resultado;

        }

        public String F_Buscar_NET(String arg)
        {
            String str_resultado = "";
            String str_mensaje_operacion = "";
            String str_grvConsulta_html = "";
            int int_resultado_operacion = 0;

            Hashtable obj_parametros = null;

            try
            {
                obj_parametros = SistemaInventario.Clases.JsonSerializer.FromJson<Hashtable>(arg);
                P_Buscar(obj_parametros, ref grvConsulta);
                if (grvConsulta.Rows.Count == 0)
                {
                    P_Inicializar_GrillaVacia_ConsultaFactura();
                    str_mensaje_operacion = "No se encontro registros.";
                }
                else
                    str_mensaje_operacion = "";


                str_grvConsulta_html = Mod_Utilitario.F_GetHtmlForControl(grvConsulta);
                int_resultado_operacion = 1;


            }
            catch (Exception ex)
            {

                str_mensaje_operacion = "Ha ocurrido el siguiente error: " + ex.Message;
                int_resultado_operacion = 0;

            }

            str_resultado =
                Convert.ToString(int_resultado_operacion)
                + "~" +
                str_mensaje_operacion
                + "~" +
                str_grvConsulta_html;


            return str_resultado;

        }

        public String F_AnularRegistro_Net(String arg)
        {
            String str_resultado = "";
            String str_mensaje_operacion = "";
            String str_grvConsulta_html = "";
            int int_resultado_operacion = 0;

            Hashtable obj_parametros = null;

            try
            {
                obj_parametros = SistemaInventario.Clases.JsonSerializer.FromJson<Hashtable>(arg);
                P_AnularRegistro(obj_parametros, ref str_mensaje_operacion);

                P_Buscar(obj_parametros, ref grvConsulta);
                if (grvConsulta.Rows.Count == 0)
                    P_Inicializar_GrillaVacia_ConsultaFactura();
                str_grvConsulta_html = Mod_Utilitario.F_GetHtmlForControl(grvConsulta);
                int_resultado_operacion = 1;

            }
            catch (Exception ex)
            {

                str_mensaje_operacion = "Ha ocurrido el siguiente error: " + ex.Message;
                int_resultado_operacion = 0;

            }

            str_resultado =
                Convert.ToString(int_resultado_operacion)
                + "~" +
                str_mensaje_operacion
                + "~" +
                str_grvConsulta_html;


            return str_resultado;

        }

        public String F_CargarGrillaVaciaConsultaArticulo_NET(String arg)
        {
            String str_resultado = "";
            String str_mensaje_operacion = "";
            String str_grvConsuArticulo_html = "";
            int int_resultado_operacion = 0;

            try
            {

                P_LlenarGrillaVacia_ConsultaArticulo();
                //str_grvConsuArticulo_html = Mod_Utilitario.F_GetHtmlForControl(grvConsultaArticulo);
                int_resultado_operacion = 1;
                str_mensaje_operacion = "";

            }
            catch (Exception ex)
            {

                str_mensaje_operacion = "Ha ocurrido el siguiente error: " + ex.Message;
                int_resultado_operacion = 0;

            }

            str_resultado =
                Convert.ToString(int_resultado_operacion)
                + "~" +
                str_mensaje_operacion
                + "~" +
                str_grvConsuArticulo_html;


            return str_resultado;

        }

        public String F_EditarTemporal_NET(String arg)
        {
            String str_resultado = "";
            String str_mensaje_operacion = "";
            String str_grvConsulta_html = "";
            int int_resultado_operacion = 0;
            String MsgError = "";
            Hashtable obj_parametros = null;

            try
            {
                obj_parametros = SistemaInventario.Clases.JsonSerializer.FromJson<Hashtable>(arg);
                P_EditarTemporal(obj_parametros, ref MsgError);
                P_Buscar(obj_parametros, ref grvConsulta);
                if (grvConsulta.Rows.Count == 0)
                {
                    P_Inicializar_GrillaVacia_ConsultaFactura();
                    str_mensaje_operacion = "No se encontro registros.";
                }
                else
                    str_mensaje_operacion = "";

                str_grvConsulta_html = Mod_Utilitario.F_GetHtmlForControl(grvConsulta);
                int_resultado_operacion = 1;

            }
            catch (Exception ex)
            {

                str_mensaje_operacion = "Ha ocurrido el siguiente error: " + ex.Message;
                int_resultado_operacion = 0;

            }

            str_resultado =
                Convert.ToString(int_resultado_operacion)
                + "~" +
                str_mensaje_operacion
                + "~" +
                str_grvConsulta_html;

            return str_resultado;

        }

        public String F_TipoCambio_NET(String arg)
        {
            String str_resultado = "";
            String str_mensaje_operacion = "";
            Decimal TipoCambio = 0;
            int int_resultado_operacion = 0;


            String MsgError = "";
            Hashtable obj_parametros = null;

            try
            {
                obj_parametros = SistemaInventario.Clases.JsonSerializer.FromJson<Hashtable>(arg);
                P_TipoCambio(obj_parametros, ref TipoCambio);
                int_resultado_operacion = 1;
                str_mensaje_operacion = MsgError;

            }
            catch (Exception ex)
            {

                str_mensaje_operacion = "Ha ocurrido el siguiente error: " + ex.Message;
                int_resultado_operacion = 0;

            }

            str_resultado =
                Convert.ToString(int_resultado_operacion)
                + "~" +
                str_mensaje_operacion
                + "~" +
                TipoCambio.ToString();


            return str_resultado;

        }

        public void P_Controles_Inicializar(Hashtable objTablaFiltro, ref DropDownList ddl_comboformapago,
             ref DropDownList ddl_combomoneda, ref DropDownList ddl_comboigv,
            ref DropDownList ddl_combodocumento, ref DropDownList ddl_comboclasificacion)
        {

            DataTable dta_consulta = null;


            TCConceptosDetCE objEntidadConceptosDet = new TCConceptosDetCE();

            objEntidadConceptosDet.CodConcepto = 4;

            TCConceptosDetCN objOperacionConceptosDet = new TCConceptosDetCN();
            dta_consulta = null;
            dta_consulta = objOperacionConceptosDet.F_TCConceptos_Select(objEntidadConceptosDet);

            ddl_combomoneda.Items.Clear();

            ddl_combomoneda.DataSource = dta_consulta;
            ddl_combomoneda.DataTextField = "DscAbvConcepto";
            ddl_combomoneda.DataValueField = "CodConcepto";
            ddl_combomoneda.DataBind();


            objEntidadConceptosDet.CodConcepto = 10;


            dta_consulta = null;
            dta_consulta = objOperacionConceptosDet.F_TCConceptos_Select(objEntidadConceptosDet);

            ddl_comboclasificacion.Items.Clear();

            ddl_comboclasificacion.DataSource = dta_consulta;
            ddl_comboclasificacion.DataTextField = "DscAbvConcepto";
            ddl_comboclasificacion.DataValueField = "CodConcepto";
            ddl_comboclasificacion.DataBind();

            dta_consulta = null;

            objEntidadConceptosDet.CodConcepto = 5;
            dta_consulta = objOperacionConceptosDet.F_TCConceptos_Select(objEntidadConceptosDet);

            ddl_comboformapago.Items.Clear();

            ddl_comboformapago.DataSource = dta_consulta;
            ddl_comboformapago.DataTextField = "DscAbvConcepto";
            ddl_comboformapago.DataValueField = "CodConcepto";
            ddl_comboformapago.DataBind();

            dta_consulta = null;
            TCTasasCE objEntidadTasa = new TCTasasCE();
            objEntidadTasa.CodTipoTasa = 1;
            objEntidadTasa.CodEstado = 0;
            TCTasasCN objOperacionTasa = new TCTasasCN();
            dta_consulta = objOperacionTasa.F_TCTasas_ListarXTipoTasa(objEntidadTasa);

            ddl_comboigv.Items.Clear();

            ddl_comboigv.DataSource = dta_consulta;
            ddl_comboigv.DataTextField = "Valor";
            ddl_comboigv.DataValueField = "CodTasa";
            ddl_comboigv.DataBind();

            dta_consulta = null;

            TCDocumentosCN objOperacionDocumento = new TCDocumentosCN();
            dta_consulta = objOperacionDocumento.F_TCDocumentos_ListarCompras();

            ddl_combodocumento.Items.Clear();

            ddl_combodocumento.DataSource = dta_consulta;
            ddl_combodocumento.DataTextField = "Descripcion";
            ddl_combodocumento.DataValueField = "CodTipoDoc";
            ddl_combodocumento.DataBind();
        }

        public void P_Obtener_TipoCambio(Hashtable objTablaFiltro, ref Decimal TipoCambio)
        {

            TCTipoCambioCE objEntidad = null;
            TCTipoCambioCN objOperacion = null;

            DataTable dta_consulta = null;

            //
            //int iCodEmpresa = 3;

            objEntidad = new TCTipoCambioCE();

            objEntidad.Fecha = Convert.ToDateTime(objTablaFiltro["Filtro_Fecha"]);

            objOperacion = new TCTipoCambioCN();

            dta_consulta = objOperacion.F_TCTipoCambio_Select(objEntidad);

            if (dta_consulta.Rows.Count > 0)
                TipoCambio = Convert.ToDecimal(dta_consulta.Rows[0]["TC_Venta"]);



        }

        public void P_Inicializar_GrillaVacia_ConsultaArticulo()
        {
            DataTable dta_consultaarticulo = null;
            DataRow dtr_consultafila = null;

            dta_consultaarticulo = new DataTable();

            dta_consultaarticulo.Columns.Add("CodProducto", typeof(string));
            dta_consultaarticulo.Columns.Add("CodUnidadVenta", typeof(string));
            dta_consultaarticulo.Columns.Add("Costo", typeof(string));
            dta_consultaarticulo.Columns.Add("CodigoProducto", typeof(string));
            dta_consultaarticulo.Columns.Add("Producto", typeof(string));
            dta_consultaarticulo.Columns.Add("Stock", typeof(string));
            dta_consultaarticulo.Columns.Add("UM", typeof(string));
            dta_consultaarticulo.Columns.Add("Precio1", typeof(string));
            dta_consultaarticulo.Columns.Add("Precio2", typeof(string));
            dta_consultaarticulo.Columns.Add("Precio3", typeof(string));
            dta_consultaarticulo.Columns.Add("Moneda", typeof(string));

            dtr_consultafila = dta_consultaarticulo.NewRow();

            dtr_consultafila[0] = "";
            dtr_consultafila[1] = "";
            dtr_consultafila[2] = "";
            dtr_consultafila[3] = "";
            dtr_consultafila[4] = "";
            dtr_consultafila[5] = "";
            dtr_consultafila[6] = "";
            dtr_consultafila[7] = "";
            dtr_consultafila[8] = "";
            dtr_consultafila[9] = "";
            dtr_consultafila[10] = "";

            dta_consultaarticulo.Rows.Add(dtr_consultafila);

            //grvConsultaArticulo.DataSource = dta_consultaarticulo;
            //grvConsultaArticulo.DataBind();

        }

        public void P_Inicializar_GrillaVacia_DetalleArticulo()
        {
            DataTable dta_consultadetalle = null;
            DataRow dtr_filadetalle = null;

            dta_consultadetalle = new DataTable();

            dta_consultadetalle.Columns.Add("CodDetalle", typeof(string));
            dta_consultadetalle.Columns.Add("CodArticulo", typeof(string));
            dta_consultadetalle.Columns.Add("CodigoProducto", typeof(string));
            dta_consultadetalle.Columns.Add("Producto", typeof(string));
            dta_consultadetalle.Columns.Add("Cantidad", typeof(string));
            dta_consultadetalle.Columns.Add("UM", typeof(string));
            dta_consultadetalle.Columns.Add("Precio", typeof(string));
            dta_consultadetalle.Columns.Add("Importe", typeof(string));

            dtr_filadetalle = dta_consultadetalle.NewRow();

            dtr_filadetalle[0] = "";
            dtr_filadetalle[1] = "";
            dtr_filadetalle[2] = "";
            dtr_filadetalle[3] = "";
            dtr_filadetalle[4] = "";
            dtr_filadetalle[5] = "";
            dtr_filadetalle[6] = "";
            dtr_filadetalle[7] = "";

            dta_consultadetalle.Rows.Add(dtr_filadetalle);

            //grvDetalleArticulo.DataSource = dta_consultadetalle;
            //grvDetalleArticulo.DataBind();

        }

        public void P_Inicializar_GrillaVacia_ConsultaFactura()
        {
            DataTable dta_consulta = null;
            DataRow dtr_filaconsulta = null;

            dta_consulta = new DataTable();

            dta_consulta.Columns.Add("Codigo", typeof(string));
            dta_consulta.Columns.Add("RazonSocial", typeof(string));
            dta_consulta.Columns.Add("Documento", typeof(string));
            dta_consulta.Columns.Add("Numero", typeof(string));
            dta_consulta.Columns.Add("Emision", typeof(string));
            dta_consulta.Columns.Add("Vcto", typeof(string));
            dta_consulta.Columns.Add("Moneda", typeof(string));
            dta_consulta.Columns.Add("Dscto", typeof(string));
            dta_consulta.Columns.Add("SubTotal", typeof(string));
            dta_consulta.Columns.Add("Saldo", typeof(string));
            dta_consulta.Columns.Add("Total", typeof(string));
            dta_consulta.Columns.Add("TipoCambio", typeof(string));
            dta_consulta.Columns.Add("Anexo", typeof(string));
            dta_consulta.Columns.Add("Estado", typeof(string));
            dta_consulta.Columns.Add("Condicion", typeof(string));
            dta_consulta.Columns.Add("Periodo", typeof(string));

            dtr_filaconsulta = dta_consulta.NewRow();

            dtr_filaconsulta[0] = "";
            dtr_filaconsulta[1] = "";
            dtr_filaconsulta[2] = "";
            dtr_filaconsulta[3] = "";
            dtr_filaconsulta[4] = "";
            dtr_filaconsulta[5] = "";
            dtr_filaconsulta[6] = "";
            dtr_filaconsulta[7] = "";
            dtr_filaconsulta[8] = "";
            dtr_filaconsulta[9] = "";
            dtr_filaconsulta[10] = "";
            dtr_filaconsulta[11] = "";
            dtr_filaconsulta[12] = "";
            dtr_filaconsulta[13] = "";
            dtr_filaconsulta[14] = "";
            dtr_filaconsulta[15] = "";

            dta_consulta.Rows.Add(dtr_filaconsulta);

            grvConsulta.DataSource = dta_consulta;
            grvConsulta.DataBind();
        }

        public void P_Cargar_Grilla(Hashtable objTablaFiltro, ref GridView grvConsulta)
        {

            LGProductosCE objEntidad = null;
            LGProductosCN objOperacion = null;



            objEntidad = new LGProductosCE();

            objEntidad.DscProducto = Convert.ToString(objTablaFiltro["Filtro_DscProducto"]);
            objEntidad.CodAlmacen = Convert.ToInt32(Session["CodSede"]);
            objEntidad.CodTipoProducto = Convert.ToInt32(objTablaFiltro["Filtro_CodTipoProducto"]);
            objEntidad.CodMoneda = Convert.ToInt32(objTablaFiltro["Filtro_CodMoneda"]);

            objOperacion = new LGProductosCN();

            grvConsulta.DataSource = objOperacion.F_LGProductos_Select_Ventas(objEntidad);
            grvConsulta.DataBind();


        }

        public void P_AgregarTemporal(Hashtable objTablaFiltro, ref Int32 Codigo, ref String MsgError)
        {

            DocumentoVentaCabCE objEntidad = null;
            DocumentoVentaCabCN objOperacion = null;

            String XmlDetalle = "";


            int iCodEmpresa = 3;


            objEntidad = new DocumentoVentaCabCE();

            objEntidad.CodEmpresa = iCodEmpresa;
            objEntidad.CodAlmacen = Convert.ToInt32(Session["CodSede"]);
            objEntidad.CodTipoDoc = Convert.ToInt32(objTablaFiltro["Filtro_CodTipoDoc"]);
            objEntidad.SerieDoc = Convert.ToString(objTablaFiltro["Filtro_SerieDoc"]); ;

            objEntidad.NumeroDoc = Convert.ToString(objTablaFiltro["Filtro_NumeroDoc"]);
            objEntidad.FechaEmision = Convert.ToDateTime(objTablaFiltro["Filtro_FechaEmision"]);
            objEntidad.FechaVencimiento = Convert.ToDateTime(objTablaFiltro["Filtro_Vencimiento"]);
            objEntidad.CodCliente = Convert.ToInt32(objTablaFiltro["Filtro_CodCliente"]);

            objEntidad.CodFormaPago = Convert.ToInt32(objTablaFiltro["Filtro_CodFormaPago"]);
            objEntidad.CodMoneda = Convert.ToInt32(objTablaFiltro["Filtro_CodMoneda"]);
            objEntidad.TipoCambio = Convert.ToDecimal(objTablaFiltro["Filtro_TipoCambio"]);
            objEntidad.SubTotal = Convert.ToDecimal(objTablaFiltro["Filtro_SubTotal"]);

            objEntidad.CodUsuario = Convert.ToInt32((Session["CodUsuario"]));
            objEntidad.CodProforma = Convert.ToInt32(objTablaFiltro["Filtro_CodProforma"]);
            objEntidad.Igv = Convert.ToDecimal(objTablaFiltro["Filtro_Igv"]);
            objEntidad.Total = Convert.ToDecimal(objTablaFiltro["Filtro_Total"]);

            objEntidad.CodGuia = Convert.ToInt32(objTablaFiltro["Filtro_CodGuia"]);
            objEntidad.Descuento = Convert.ToInt32(objTablaFiltro["Filtro_Descuento"]);

            dynamic jArr2 = Newtonsoft.Json.JsonConvert.DeserializeObject(objTablaFiltro["Filtro_XmlDetalle"].ToString());

            foreach (dynamic item in jArr2)
            {
                XmlDetalle = XmlDetalle + "<D ";
                XmlDetalle = XmlDetalle + " CodArticulo = '" + item.CodArticulo + "'";
                XmlDetalle = XmlDetalle + " Cantidad = '" + item.Cantidad + "'";
                XmlDetalle = XmlDetalle + " Precio = '" + item.Precio / (Convert.ToDecimal(objTablaFiltro["Filtro_TasaIgvDscto"])) + "'";
                XmlDetalle = XmlDetalle + " PrecioDscto = '" + (item.Precio / (Convert.ToDecimal(objTablaFiltro["Filtro_TasaIgvDscto"]))) * (1 - (Convert.ToDecimal(item.Dscto) / 100)) + "'";
                XmlDetalle = XmlDetalle + " Costo = '" + item.Costo + "'";
                XmlDetalle = XmlDetalle + " CodUm = '" + item.CodUm + "'";
                XmlDetalle = XmlDetalle + " />";
            }

            XmlDetalle = "<R><XmlLC> " + XmlDetalle + "</XmlLC></R>";

            objEntidad.XmlDetalle = XmlDetalle;

            objOperacion = new DocumentoVentaCabCN();

            if (Convert.ToInt32(objTablaFiltro["Filtro_CodigoTemporal"]) == 0)
            {
                objOperacion.F_TemporalFacturacionDet_Insert(objEntidad);
                Codigo = objEntidad.CodDocumentoVenta;
            }
            else
            {
                objEntidad.CodDocumentoVenta = Convert.ToInt32(objTablaFiltro["Filtro_CodigoTemporal"]);
                objOperacion.F_TemporalFacturacionDetalle_Insert(objEntidad);
                Codigo = Convert.ToInt32(objTablaFiltro["Filtro_CodigoTemporal"]);
            }
            MsgError = objEntidad.MsgError;

        }

        public void P_EliminarTemporal(Hashtable objTablaFiltro, ref String MsgError)
        {

            DocumentoVentaDetCE objEntidad = null;
            DocumentoVentaDetCN objOperacion = null;

            String XmlDetalle = "";

            objEntidad = new DocumentoVentaDetCE();

            dynamic jArr2 = Newtonsoft.Json.JsonConvert.DeserializeObject(objTablaFiltro["Filtro_XmlDetalle"].ToString());

            foreach (dynamic item in jArr2)
            {
                XmlDetalle = XmlDetalle + "<D ";
                XmlDetalle = XmlDetalle + " CodDetalle = '" + item.CodDetalle + "'";
                XmlDetalle = XmlDetalle + " />";
            }

            XmlDetalle = "<R><XmlLC> " + XmlDetalle + "</XmlLC></R>";

            objEntidad.XmlDetalle = XmlDetalle;

            objOperacion = new DocumentoVentaDetCN();

            objOperacion.F_TemporalFacturacionDet_Eliminar(objEntidad);

            MsgError = objEntidad.MsgError;

        }

        public void P_CargarGrillaTemporal(Hashtable objTablaFiltro, Int32 Codigo, ref GridView grvDetalle,
            ref Decimal SubTotalFactura, ref Decimal IgvFactura, ref Decimal TotalFactura, ref Decimal TotalDscto)
        {

            DocumentoVentaCabCE objEntidad = null;
            DocumentoVentaCabCN objOperacion = null;

            objEntidad = new DocumentoVentaCabCE();


            objOperacion = new DocumentoVentaCabCN();


            DataTable dta_consulta = null;
            if (Codigo != 0)
            {
                objEntidad.Igv = Convert.ToDecimal(objTablaFiltro["Filtro_TasaIgv"]);
                objEntidad.CodDocumentoVenta = Codigo;

                dta_consulta = objOperacion.F_TemporalFacturacionDet_Listar(objEntidad);
            }
            if (dta_consulta.Rows.Count > 0)
            {
                for (int j = 0; j < dta_consulta.Rows.Count; j++)
                {
                    TotalFactura += Convert.ToDecimal(dta_consulta.Rows[j]["Importe"]);
                    TotalDscto += Convert.ToDecimal(dta_consulta.Rows[j]["Dscto"]);
                }

                SubTotalFactura = (TotalFactura / Convert.ToDecimal(objTablaFiltro["Filtro_TasaIgv"]));
                IgvFactura = SubTotalFactura * (Convert.ToDecimal(objTablaFiltro["Filtro_TasaIgv"]) - 1);
            }
            grvDetalle.DataSource = dta_consulta;
            grvDetalle.DataBind();



        }

        public void P_GrabarDocumento(Hashtable objTablaFiltro, ref String MsgError, ref Int32 Codigo)
        {
            NotaIngresoSalidaCabCE objEntidad = null;
            NotaIngresoSalidaCabCN objOperacion = null;

            objEntidad = new NotaIngresoSalidaCabCE();
            int iCodEmpresa = 3;

            objEntidad.CodTipoOperacion = 2;
            objEntidad.CodAlmacen = Convert.ToInt32(Session["CodSede"]);
            objEntidad.CodTipoDocSust = Convert.ToInt32(objTablaFiltro["Filtro_CodTipoDoc"]);
            objEntidad.SerieDocSust = Convert.ToString(objTablaFiltro["Filtro_SerieDocSust"]);
            objEntidad.NumeroDocSust = Convert.ToString(objTablaFiltro["Filtro_NumeroDocSust"]);
            objEntidad.FechaIngreso = Convert.ToDateTime(objTablaFiltro["Filtro_FechaIngreso"]);
            objEntidad.CodUsuario = Convert.ToInt32((Session["CodUsuario"]));
            objEntidad.FechaRegistro = Convert.ToDateTime(objTablaFiltro["Filtro_FechaRegistro"]);
            objEntidad.CodMoneda = Convert.ToInt32(objTablaFiltro["Filtro_CodMoneda"]);
            objEntidad.CodEstado = 6;
            objEntidad.CodCtaCte = Convert.ToInt32(objTablaFiltro["Filtro_CodCtaCte"]);
            objEntidad.CodEmpresa = iCodEmpresa;
            objEntidad.ImpSubTotal = Convert.ToDecimal(objTablaFiltro["Filtro_ImpSubTotal"]);
            objEntidad.ImpIGV = Convert.ToDecimal(objTablaFiltro["Filtro_ImpIGV"]);
            objEntidad.ImpTotal = Convert.ToDecimal(objTablaFiltro["Filtro_ImpTotal"]);
            objEntidad.CodFormaPago = Convert.ToInt32(objTablaFiltro["Filtro_CodFormaPago"]);
            objEntidad.Descuento = Convert.ToDecimal(objTablaFiltro["Filtro_Descuento"]);
            objEntidad.TipoCambio = Convert.ToDecimal(objTablaFiltro["Filtro_TipoCambio"]);
            objEntidad.CodTasa = Convert.ToInt32(objTablaFiltro["Filtro_CodTasa"]);
            objEntidad.Periodo = Convert.ToInt32(objTablaFiltro["Filtro_Periodo"]);
            objEntidad.Vencimiento = Convert.ToDateTime(objTablaFiltro["Filtro_Vencimiento"]);
            objEntidad.CodClasificacion = Convert.ToInt32(objTablaFiltro["Filtro_CodClasificacion"]);
            objEntidad.CodCategoria = Convert.ToInt32(objTablaFiltro["Filtro_CodCategoria"]);

            if (Convert.ToInt32(objTablaFiltro["Filtro_CodFormaPago"]) == 12)
                objEntidad.FlagLetra = 1;
            else
                objEntidad.FlagLetra = 0;

            objOperacion = new NotaIngresoSalidaCabCN();

            objOperacion.F_NotaIngresoSalidaCab_InsertGastos(objEntidad);

            MsgError = objEntidad.MsgError;
        }

        public void P_LlenarGrillaVacia_Detalle()
        {
            DataTable dta_consultadetalle = null;
            DataRow dtr_filadetalle = null;

            dta_consultadetalle = new DataTable();

            dta_consultadetalle.Columns.Add("CodDetalle", typeof(string));
            dta_consultadetalle.Columns.Add("CodArticulo", typeof(string));
            dta_consultadetalle.Columns.Add("CodigoProducto", typeof(string));
            dta_consultadetalle.Columns.Add("Producto", typeof(string));
            dta_consultadetalle.Columns.Add("Cantidad", typeof(string));
            dta_consultadetalle.Columns.Add("UM", typeof(string));
            dta_consultadetalle.Columns.Add("Precio", typeof(string));
            dta_consultadetalle.Columns.Add("Importe", typeof(string));

            dtr_filadetalle = dta_consultadetalle.NewRow();

            dtr_filadetalle[0] = "";
            dtr_filadetalle[1] = "";
            dtr_filadetalle[2] = "";
            dtr_filadetalle[3] = "";
            dtr_filadetalle[4] = "";
            dtr_filadetalle[5] = "";
            dtr_filadetalle[6] = "";
            dtr_filadetalle[7] = "";

            dta_consultadetalle.Rows.Add(dtr_filadetalle);

            //grvDetalleArticulo.DataSource = dta_consultadetalle;
            //grvDetalleArticulo.DataBind();

        }

        public void P_Buscar(Hashtable objTablaFiltro, ref GridView GrillaBuscar)
        {

            NotaIngresoSalidaCabCE objEntidad = null;
            NotaIngresoSalidaCabCN objOperacion = null;

            DataTable dta_consulta = null;

            //
            int iCodEmpresa = 3;

            objEntidad = new NotaIngresoSalidaCabCE();


            objEntidad.CodTipoOperacion = 2;
            objEntidad.CodEmpresa = iCodEmpresa;
            objEntidad.CodAlmacen = Convert.ToInt32(Session["CodSede"]);
            objEntidad.CodTipoDoc = 7;
            objEntidad.CodClasificacion = Convert.ToInt32(objTablaFiltro["Filtro_CodClasificacion"]);

            if (Convert.ToInt32(objTablaFiltro["Filtro_ChkNumero"]) == 1)
            {
                objEntidad.NumeroDoc = Convert.ToString(objTablaFiltro["Filtro_Numero"]);

            }
            else
            {

                objEntidad.NumeroDoc = "";
            }


            if (Convert.ToInt32(objTablaFiltro["Filtro_ChkFecha"]) == 1)
            {
                objEntidad.Desde = Convert.ToDateTime(objTablaFiltro["Filtro_Desde"]);
                objEntidad.Hasta = Convert.ToDateTime(objTablaFiltro["Filtro_Hasta"]);
            }
            else
            {
                objEntidad.Desde = Convert.ToDateTime("01/01/1990");
                objEntidad.Hasta = Convert.ToDateTime("01/01/1990");
            }


            if (Convert.ToInt32(objTablaFiltro["Filtro_ChkCliente"]) == 1)
                objEntidad.CodCtaCte = Convert.ToInt32(objTablaFiltro["Filtro_CodCtaCte"]);
            else
                objEntidad.CodCtaCte = 0;

            objOperacion = new NotaIngresoSalidaCabCN();

            dta_consulta = objOperacion.F_NotaIngresoSalidaCab_Select_Compras(objEntidad);

            GrillaBuscar.DataSource = dta_consulta;
            GrillaBuscar.DataBind();

        }

        public void P_AnularRegistro(Hashtable objTablaFiltro, ref String Mensaje)
        {

            NotaIngresoSalidaCabCE objEntidad = null;
            NotaIngresoSalidaCabCN objOperacion = null;

            objEntidad = new NotaIngresoSalidaCabCE();


            objEntidad.CodMovimiento = Convert.ToInt32(objTablaFiltro["Filtro_Codigo"]);

            objOperacion = new NotaIngresoSalidaCabCN();

            objOperacion.F_Anulacion_NotaIngreso(objEntidad);

            Mensaje = objEntidad.MsgError;



        }

        public void P_LlenarGrillaVacia_ConsultaArticulo()
        {
            DataTable dta_consultaarticulo = null;
            DataRow dtr_consultafila = null;

            dta_consultaarticulo = new DataTable();

            dta_consultaarticulo.Columns.Add("CodProducto", typeof(string));
            dta_consultaarticulo.Columns.Add("CodUnidadVenta", typeof(string));
            dta_consultaarticulo.Columns.Add("Costo", typeof(string));
            dta_consultaarticulo.Columns.Add("CodigoProducto", typeof(string));
            dta_consultaarticulo.Columns.Add("Producto", typeof(string));
            dta_consultaarticulo.Columns.Add("Stock", typeof(string));
            dta_consultaarticulo.Columns.Add("UM", typeof(string));
            dta_consultaarticulo.Columns.Add("Precio1", typeof(string));
            dta_consultaarticulo.Columns.Add("Precio2", typeof(string));
            dta_consultaarticulo.Columns.Add("Precio3", typeof(string));
            dta_consultaarticulo.Columns.Add("Moneda", typeof(string));

            dtr_consultafila = dta_consultaarticulo.NewRow();

            dtr_consultafila[0] = "";
            dtr_consultafila[1] = "";
            dtr_consultafila[2] = "";
            dtr_consultafila[3] = "";
            dtr_consultafila[4] = "";
            dtr_consultafila[5] = "";
            dtr_consultafila[6] = "";
            dtr_consultafila[7] = "";
            dtr_consultafila[8] = "";
            dtr_consultafila[9] = "";
            dtr_consultafila[10] = "";


            dta_consultaarticulo.Rows.Add(dtr_consultafila);

            //grvConsultaArticulo.DataSource = dta_consultaarticulo;
            //grvConsultaArticulo.DataBind();

        }

        public void P_EditarTemporal(Hashtable objTablaFiltro, ref String MsgError)
        {

            NotaIngresoSalidaCabCE objEntidad = null;
            NotaIngresoSalidaCabCN objOperacion = null;

            objEntidad = new NotaIngresoSalidaCabCE();

            objEntidad.CodMovimiento = Convert.ToInt32(objTablaFiltro["Filtro_CodMovimiento"]);
            objEntidad.Periodo = Convert.ToInt32(objTablaFiltro["Filtro_Periodo"]);

            objOperacion = new NotaIngresoSalidaCabCN();

            objOperacion.F_NotaIngresoSalidaCab_Update(objEntidad);


        }

        public void P_TipoCambio(Hashtable objTablaFiltro, ref Decimal TC)
        {

            TCTipoCambioCE objEntidad = null;
            TCTipoCambioCN objOperacion = null;

            objEntidad = new TCTipoCambioCE();
            objEntidad.Fecha = Convert.ToDateTime(objTablaFiltro["Filtro_Emision"]);

            objOperacion = new TCTipoCambioCN();

            DataTable dta_consulta = null;

            dta_consulta = objOperacion.F_TCTipoCambio_Select(objEntidad);

            if (dta_consulta.Rows.Count == 0)
                TC = 0;
            else
                TC = Convert.ToDecimal(dta_consulta.Rows[0][0]);


        }
    }
}