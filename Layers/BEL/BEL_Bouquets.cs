using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace NatufloraDistribuidoraApl.Old_App_Code.Natuflora.BD.Layers.BEL
{
    public class BEL_RecipePO
    {
        public Int32? id_version_bouquet { get; set; }
        public Int32? id_detalle_po { get; set; }
        public String nombre_tipo_flor { get; set; }
        public String nombre_variedad_flor { get; set; }
        public String nombre_grado_flor { get; set; }
        public String nombre_tapa { get; set; }
        public Int32? cantidad_piezas { get; set; }
        public String nombre_tipo_caja { get; set; }
        public Int32? unidades { get; set; }
        public String marca { get; set; }
        public Decimal? precio_miami_pieza { get; set; }
        public Boolean? ethyblock_sachet { get; set; }
        public String item_number { get; set; }
        public String nombre_farm { get; set; }
        public String imagen { get; set; }
        public Boolean id_status { get; set; } 
    }

    public class BEL_Bouquet
    {
        public Int32? id_detalle_version_bouquet { get; set; } 
        public Int32? id_formula_bouquet { get; set; }
        public String especificacion_bouquet { get; set; }
        public String construccion_bouquet { get; set; }
        public String nombre_formula_bouquet { get; set; }
        public Decimal precio_miami { get; set; }
        public Int32 unidades { get; set; }
    }

    public class BEL_BouquetSelected
    {
        public Int32? id_formula_bouquet { get; set; }
        public String especificacion_bouquet { get; set; }
        public String construccion_bouquet { get; set; }
        public String nombre_formula_bouquet { get; set; }
    }

    public class BEL_DetailBouquet
    {
        public Int32? id_detalle_version_bouquet { get; set; }
        public Int32? unidades { get; set; }
        public Decimal? precio_miami { get; set; }
        public Int32? id_comida_bouquet { get; set; }
        public String nombre_comida { get; set; }
        public Int32? id_formula_bouquet { get; set; }
        public String nombre_formula_bouquet { get; set; }
        public String especificacion_bouquet { get; set; }
        public String construccion_bouquet { get; set; }
        public String upc { get; set; }
        public Int32? orden_upc { get; set; }
        public String descripcion_upc { get; set; }
        public Int32? orden_descripcion_upc { get; set; }
        public String fecha_upc { get; set; }
        public Int32? orden_fecha_upc { get; set; }
        public String precio_upc { get; set; }
        public Int32? orden_precio_upc { get; set; }
        public Int32? id_formato_upc { get; set; }
        public String nombre_formato { get; set; }
    }

    public class BEL_DetailBouquetSelected
    {
        public Int32? id_detalle_formula_bouquet { get; set; }
        public Int32? id_detalle_version_bouquet { get; set; }
        public Int32? unidades { get; set; }
        public Decimal? precio_miami { get; set; }
        public Int32? id_comida_bouquet { get; set; }
        public String nombre_comida { get; set; }
        public String upc { get; set; }
        public Int32? orden_upc { get; set; }
        public String descripcion_upc { get; set; }
        public Int32? orden_descripcion_upc { get; set; }
        public String fecha_upc { get; set; }
        public Int32? orden_fecha_upc { get; set; }
        public String precio_upc { get; set; }
        public Int32? orden_precio_upc { get; set; }
        public Int32? id_tipo_flor_cultivo { get; set; }
        public String nombre_tipo_flor { get; set; }
        public Int32? id_variedad_flor_cultivo { get; set; }
        public String nombre_variedad_flor { get; set; }
        public Int32? id_grado_flor_cultivo { get; set; }
        public String nombre_grado_flor { get; set; }
        public String nombre_tipo_flor_sustitucion { get; set; }
        public String nombre_variedad_flor_sustitucion { get; set; }
        public String nombre_grado_flor_sustitucion { get; set; }
        public Int32? cantidad_tallos { get; set; }
        public String observacion { get; set; }
    }

    public class BEL_Sleeve
    {
        public Int32? id_capuchon_cultivo { get; set; }
        public String nombre_capuchon { get; set; }
    }

    public class BEL_Sticker
    {
        public Int32? id_sticker { get; set; }
        public String nombre_sticker { get; set; }
    }

    public class BEL_Food
    {
        public Int32? id_comida_bouquet { get; set; }
        public String nombre_comida_bouquet { get; set; }
    }

    public class BEL_DetailFormulaOP3
    {
        public String nombre_flor { get; set; }
        public String cantidad_tallos { get; set; }
    }

    public class BEL_GenericResponse
    {
        public Int32? response { get; set; }
        public String responseMessage { get; set; }
    }

    public class BEL_FlowerType
    {
        public Int32? id_tipo_flor_cultivo { get; set; }
        public String nombre_tipo_flor { get; set; }
    }

    public class BEL_FlowerVariety
    {
        public Int32? id_variedad_flor_cultivo { get; set; }
        public String nombre_variedad_flor { get; set; }
    }

    public class BEL_FlowerGrade
    {
        public Int32? id_grado_flor_cultivo { get; set; }
        public String nombre_grado_flor { get; set; }
    }

    public class BEL_UPC
    {
        public String upc { get; set; }
        public String orden_upc { get; set; }
        public String descripcion_upc { get; set; }
        public Int32? orden_descripcion_upc { get; set; }
        public String precio_upc { get; set; }
        public Int32? orden_precio_upc { get; set; }
        public String fecha_upc { get; set; }
        public Int32? orden_fecha_upc { get; set; }
        public String nombre_informacion_upc { get; set; }
    }

    public class BEL_FormatoUPC
    {
        public Int32? id_formato_upc { get; set; }
        public String nombre_formato { get; set; }
    }

    public class BEL_BouquetRecipe
    {
        public Int32? id_tipo_flor_cultivo { get; set; }
        public String nombre_tipo_flor { get; set; }
        public Int32? id_variedad_flor_cultivo { get; set; }
        public String nombre_variedad_flor { get; set; }
        public Int32? id_grado_flor_cultivo { get; set; }
        public String nombre_grado_flor { get; set; }
        public Int32? cantidad_tallos { get; set; }
        public String observacion { get; set; }
        public Int32? id_formula_bouquet { get; set; }

        //Substitution//
        public Int32? id_tipo_flor_cultivo_sustitucion { get; set; }
        public String nombre_tipo_flor_sustitucion { get; set; }
        public Int32? id_variedad_flor_cultivo_sustitucion { get; set; }
        public String nombre_variedad_flor_sustitucion { get; set; }
        public Int32? id_grado_flor_cultivo_sustitucion { get; set; }
        public String nombre_grado_flor_sustitucion { get; set; }
    }
}