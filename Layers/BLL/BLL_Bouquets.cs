using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using NatufloraDistribuidoraApl.Old_App_Code.Natuflora.BD.Layers.BEL;
using System.Text;
using System.Drawing;

namespace NatufloraDistribuidoraApl.Old_App_Code.Natuflora.BD.Layers.BLL
{
    public class BLL_Bouquets
    {
        //ConstruirDetallePO
        public List<BEL_RecipePO> BuildRecipePO(DataTable dt)
        {
            var query = from detPO in dt.AsEnumerable()
                        select new BEL_RecipePO
                        {
                            id_detalle_po = detPO.Table.Columns.Contains("id_detalle_po") ? detPO.Field<Int32?>("id_detalle_po") : null,
                            id_version_bouquet = detPO.Table.Columns.Contains("id_version_bouquet") ? detPO.Field<Int32?>("id_version_bouquet") : null,
                            nombre_tipo_flor = detPO.Table.Columns.Contains("nombre_tipo_flor") ? detPO.Field<String>("nombre_tipo_flor") : null,
                            nombre_variedad_flor = detPO.Table.Columns.Contains("nombre_variedad_flor") ? detPO.Field<String>("nombre_variedad_flor") : null,
                            nombre_grado_flor = detPO.Table.Columns.Contains("nombre_grado_flor") ? detPO.Field<String>("nombre_grado_flor") : null,
                            nombre_tapa = detPO.Table.Columns.Contains("nombre_tapa") ? detPO.Field<String>("nombre_tapa") : null,
                            cantidad_piezas = detPO.Table.Columns.Contains("cantidad_piezas") ? detPO.Field<Int32?>("cantidad_piezas") : null,
                            nombre_tipo_caja = detPO.Table.Columns.Contains("nombre_tipo_caja") ? detPO.Field<String>("nombre_tipo_caja") : null,
                            unidades = detPO.Table.Columns.Contains("unidades") ? detPO.Field<Int32?>("unidades") : null,
                            marca = detPO.Table.Columns.Contains("marca") ? detPO.Field<String>("marca") : null,
                            precio_miami_pieza = detPO.Table.Columns.Contains("marca") ? detPO.Field<Decimal?>("precio_miami_pieza") : null,
                            ethyblock_sachet = detPO.Table.Columns.Contains("ethyblock_sachet") ? detPO.Field<Boolean?>("ethyblock_sachet") : null,
                            item_number = String.IsNullOrEmpty(detPO.Table.Columns.Contains("item_number") ? detPO.Field<String>("item_number") : String.Empty) ? String.Empty : detPO.Field<String>("item_number"),
                            nombre_farm = detPO.Table.Columns.Contains("nombre_farm") ? detPO.Field<String>("nombre_farm") : null,
                            imagen = Convert.ToBase64String(detPO.Field<Byte[]>("imagen") == null ? GetImageNoFound() : detPO.Field<Byte[]>("imagen")),
                            id_status = detPO.Field<Boolean>("id_status")
                        };
            
            return query.ToList<BEL_RecipePO>();
        }

        //ConstruirRecetas
        public List<BEL_Bouquet> BuildBouquet(DataTable dt)
        {
            var query = from tb in dt.AsEnumerable()
                        select new BEL_Bouquet
                        {
                            id_detalle_version_bouquet = tb.Field<Int32?>("id_detalle_version_bouquet"),
                            id_formula_bouquet = tb.Field<Int32?>("id_formula_bouquet"),
                            especificacion_bouquet = tb.Field<String>("especificacion_bouquet"),
                            construccion_bouquet = tb.Field<String>("construccion_bouquet"),
                            nombre_formula_bouquet = tb.Field<String>("nombre_formula_bouquet"),
                            precio_miami = tb.Field<Decimal>("precio_miami") / tb.Field<Int32>("unidades"),
                            unidades = tb.Field<Int32>("unidades")
                        };
            return query.ToList<BEL_Bouquet>();
        }

        public List<BEL_BouquetSelected> BuildBouquetSelected(DataTable dt)
        {
            var query = from tb in dt.AsEnumerable()
                        select new BEL_BouquetSelected
                        {
                            id_formula_bouquet = tb.Field<Int32?>("id_formula_bouquet"),
                            especificacion_bouquet = tb.Field<String>("especificacion_bouquet"),
                            construccion_bouquet = tb.Field<String>("construccion_bouquet"),
                            nombre_formula_bouquet = tb.Field<String>("nombre_formula_bouquet")
                        };
            return query.ToList<BEL_BouquetSelected>();
        }

        public List<BEL_DetailBouquet> BuildDetailBouquet(DataTable dt)
        {
            var query = from tb in dt.AsEnumerable()
                        select new BEL_DetailBouquet
                        {
                            id_detalle_version_bouquet = tb.Field<Int32?>("id_detalle_version_bouquet"),
                            id_formula_bouquet = tb.Field<Int32?>("id_formula_bouquet"),
                            especificacion_bouquet = tb.Field<String>("especificacion_bouquet"),
                            construccion_bouquet = tb.Field<String>("construccion_bouquet"),
                            nombre_formula_bouquet = tb.Field<String>("nombre_formula_bouquet"),
                            id_comida_bouquet = tb.Field<Int32?>("id_comida_bouquet"),
                            nombre_comida = tb.Field<String>("nombre_comida"),
                            precio_miami = tb.Field<Decimal>("precio_miami") / tb.Field<Int32>("unidades"),
                            unidades = tb.Field<Int32?>("unidades"),
                            upc = tb.Field<String>("upc"),
                            orden_upc = tb.Field<Int32?>("orden_upc"),
                            descripcion_upc = tb.Field<String>("descripcion_upc"),
                            orden_descripcion_upc = tb.Field<Int32?>("orden_descripcion_upc"),
                            fecha_upc = tb.Field<String>("fecha_upc"),
                            orden_fecha_upc = tb.Field<Int32?>("orden_fecha_upc"),
                            precio_upc = tb.Field<String>("precio_upc"),
                            orden_precio_upc = tb.Field<Int32?>("orden_precio_upc"),
                            id_formato_upc = tb.Field<Int32?>("id_formato_upc") == null ? 0 : tb.Field<Int32?>("id_formato_upc"),
                            nombre_formato = tb.Field<String>("nombre_formato")
                        };
            return query.ToList<BEL_DetailBouquet>();
        }

        public List<BEL_DetailBouquetSelected> BuildDetailBouquetSelected(DataTable dt)
        {
            var query = from tb in dt.AsEnumerable()
                        select new BEL_DetailBouquetSelected
                        {
                            id_detalle_formula_bouquet = tb.Field<Int32?>("id_detalle_formula_bouquet"),
                            id_detalle_version_bouquet = tb.Field<Int32?>("id_detalle_version_bouquet"),
                            id_comida_bouquet = tb.Field<Int32?>("id_comida_bouquet"),
                            nombre_comida = tb.Field<String>("nombre_comida"),
                            precio_miami = tb.Field<Decimal?>("precio_miami"),
                            unidades = tb.Field<Int32?>("unidades"),
                            upc = tb.Field<String>("upc") ?? String.Empty,
                            orden_upc = tb.Field<Int32?>("orden_upc"),
                            descripcion_upc = tb.Field<String>("descripcion_upc") ?? String.Empty,
                            orden_descripcion_upc = tb.Field<Int32?>("orden_descripcion_upc"),
                            fecha_upc = tb.Field<String>("fecha_upc") ?? String.Empty,
                            orden_fecha_upc = tb.Field<Int32?>("orden_fecha_upc"),
                            precio_upc = tb.Field<String>("precio_upc") ?? String.Empty,
                            orden_precio_upc = tb.Field<Int32?>("orden_precio_upc"),
                            id_tipo_flor_cultivo = tb.Field<Int32?>("id_tipo_flor_cultivo"),
                            nombre_tipo_flor = tb.Field<String>("nombre_tipo_flor") ?? String.Empty,
                            id_variedad_flor_cultivo = tb.Field<Int32?>("id_variedad_flor_cultivo"),
                            nombre_variedad_flor = tb.Field<String>("nombre_variedad_flor") ?? String.Empty,
                            id_grado_flor_cultivo = tb.Field<Int32?>("id_grado_flor_cultivo"),
                            nombre_grado_flor = tb.Field<String>("nombre_grado_flor") ?? String.Empty,
                            nombre_tipo_flor_sustitucion = tb.Field<String>("nombre_tipo_flor_sustitucion") ?? String.Empty,
                            nombre_variedad_flor_sustitucion = tb.Field<String>("nombre_variedad_flor_sustitucion") ?? String.Empty,
                            nombre_grado_flor_sustitucion = tb.Field<String>("nombre_grado_flor_sustitucion") ?? String.Empty,
                            cantidad_tallos = tb.Field<Int32?>("cantidad_tallos"),
                            observacion = tb.Field<String>("observacion") ?? String.Empty
                        };
            return query.ToList<BEL_DetailBouquetSelected>();
        }

        public List<BEL_Sleeve> BuildSleeve(DataTable dt)
        {
            var query = from tb in dt.AsEnumerable()
                        select new BEL_Sleeve
                        {
                            id_capuchon_cultivo = tb.Field<Int32?>("id_capuchon_cultivo"),
                            nombre_capuchon = tb.Field<String>("nombre_capuchon")
                        };
            return query.ToList<BEL_Sleeve>();
        }

        public List<BEL_Sticker> BuildSticker(DataTable dt)
        {
            var query = from tb in dt.AsEnumerable()
                        select new BEL_Sticker
                        {
                            id_sticker = tb.Field<Int32?>("id_sticker"),
                            nombre_sticker = tb.Field<String>("nombre_sticker")
                        };
            return query.ToList<BEL_Sticker>();
        }

        public List<BEL_Food> BuildFood(DataTable dt)
        {
            var query = from tb in dt.AsEnumerable()
                        select new BEL_Food
                        {
                            id_comida_bouquet = tb.Field<Int32?>("id_comida_bouquet"),
                            nombre_comida_bouquet = tb.Field<String>("nombre_comida_bouquet")
                        };
            return query.ToList<BEL_Food>();
        }

        public List<BEL_FormatoUPC> BuildFormatoUPC(DataTable dt)
        {
            var query = from tb in dt.AsEnumerable()
                        select new BEL_FormatoUPC
                        {
                            id_formato_upc = tb.Field<Int32?>("id_formato_upc"),
                            nombre_formato = tb.Field<String>("nombre_formato")
                        };
            return query.ToList<BEL_FormatoUPC>();
        }

        public List<BEL_DetailFormulaOP3> BuildDetailFormulaOP3(DataTable dt)
        {
            var query = from tb in dt.AsEnumerable()
                        select new BEL_DetailFormulaOP3
                        {
                            nombre_flor = tb.Field<String>("nombre_flor"),
                            cantidad_tallos = tb.Field<String>("cantidad_tallos"),
                        };
            return query.ToList<BEL_DetailFormulaOP3>();
        }

        public List<BEL_GenericResponse> BuildGenericResponse(DataTable dt)
        {
            var query = from tb in dt.AsEnumerable()
                        select new BEL_GenericResponse
                        {
                            response = tb.Field<Int32?>(0)
                        };
            return query.ToList<BEL_GenericResponse>();
        }

        public List<BEL_GenericResponse> BuildGenericResponse(String message)
        {
            List<BEL_GenericResponse> response = new List<BEL_GenericResponse>();
            response.Add(new BEL_GenericResponse { responseMessage = "_removed" });
            return response;
        }

        public List<BEL_FlowerType> BuildFlowerType(DataTable dt)
        {
            var query = from tb in dt.AsEnumerable()
                        select new BEL_FlowerType
                        {
                            id_tipo_flor_cultivo = tb.Field<Int32?>("id_tipo_flor_cultivo"),
                            nombre_tipo_flor = tb.Field<String>("nombre_tipo_flor")
                        };
            return query.ToList<BEL_FlowerType>();
        }

        public List<BEL_FlowerVariety> BuildFlowerVariety(DataTable dt)
        {
            var query = from tb in dt.AsEnumerable()
                        select new BEL_FlowerVariety
                        {
                            id_variedad_flor_cultivo = tb.Field<Int32?>("id_variedad_flor_cultivo"),
                            nombre_variedad_flor = tb.Field<String>("nombre_variedad_flor")
                        };
            return query.ToList<BEL_FlowerVariety>();
        }

        public List<BEL_FlowerGrade> BuildFlowerGrade(DataTable dt)
        {
            var query = from tb in dt.AsEnumerable()
                        select new BEL_FlowerGrade
                        {
                            id_grado_flor_cultivo = tb.Field<Int32?>("id_grado_flor_cultivo"),
                            nombre_grado_flor = tb.Field<String>("nombre_grado_flor").Trim()
                        };
            return query.ToList<BEL_FlowerGrade>();
        }

        public List<BEL_BouquetRecipe> BuildBouquetRecipe(DataTable dt)
        {
            var query = from tb in dt.AsEnumerable()
                        select new BEL_BouquetRecipe
                        {
                            id_tipo_flor_cultivo = tb.Field<Int32?>("id_tipo_flor_cultivo"),
                            nombre_tipo_flor = tb.Field<String>("nombre_tipo_flor") ?? String.Empty,
                            id_variedad_flor_cultivo = tb.Field<Int32?>("id_variedad_flor_cultivo"),
                            nombre_variedad_flor = tb.Field<String>("nombre_variedad_flor") ?? String.Empty,
                            id_grado_flor_cultivo = tb.Field<Int32?>("id_grado_flor_cultivo"),
                            nombre_grado_flor = tb.Field<String>("nombre_grado_flor") ?? String.Empty,
                            observacion = tb.Field<String>("observacion") ?? String.Empty,
                            cantidad_tallos = tb.Field<Int32?>("cantidad_tallos") ?? 0,
                            id_tipo_flor_cultivo_sustitucion = tb.Field<Int32?>("id_tipo_flor_cultivo_sustitucion"),
                            nombre_tipo_flor_sustitucion = tb.Field<String>("nombre_tipo_flor_sustitucion") ?? String.Empty,
                            id_variedad_flor_cultivo_sustitucion = tb.Field<Int32?>("id_variedad_flor_cultivo_sustitucion"),
                            nombre_variedad_flor_sustitucion = tb.Field<String>("nombre_variedad_flor_sustitucion") ?? String.Empty,
                            id_grado_flor_cultivo_sustitucion = tb.Field<Int32?>("id_grado_flor_cultivo_sustitucion"),
                            nombre_grado_flor_sustitucion = tb.Field<String>("nombre_grado_flor_sustitucion") ?? String.Empty
                        };
            return query.ToList<BEL_BouquetRecipe>();
        }

        public List<BEL_BouquetRecipe> BuildSearchBouquet(DataTable dt)
        {
            var query = from tb in dt.AsEnumerable()
                        select new BEL_BouquetRecipe
                        {
                            id_tipo_flor_cultivo = tb.Field<Int32?>("id_tipo_flor_cultivo"),
                            nombre_tipo_flor = tb.Field<String>("nombre_tipo_flor") ?? String.Empty,
                            id_variedad_flor_cultivo = tb.Field<Int32?>("id_variedad_flor_cultivo"),
                            nombre_variedad_flor = tb.Field<String>("nombre_variedad_flor") ?? String.Empty,
                            id_grado_flor_cultivo = tb.Field<Int32?>("id_grado_flor_cultivo"),
                            nombre_grado_flor = tb.Field<String>("nombre_grado_flor") ?? String.Empty
                        };
            return query.ToList<BEL_BouquetRecipe>();
        }

        public IEnumerable<Dictionary<String, String>> GenericBuilder(DataTable dt)
        {
            var columns = dt.Columns.Cast<DataColumn>().ToArray();
            return dt.Rows.Cast<DataRow>().Select(r => columns.ToDictionary(c => c.ColumnName, c => r[c].ToString()));
        }

        public Byte[] GetImageNoFound()
        {
            Image img = Image.FromFile(HttpContext.Current.Server.MapPath("~/images/noDisponibleMin.png"), true);
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            img.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
            return ms.ToArray();
        }
    }
}