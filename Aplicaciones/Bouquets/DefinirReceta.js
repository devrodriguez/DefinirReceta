//#region tsort
(function (factory) {
    'use strict';
    if (typeof define === 'function' && define.amd) {
        define(['jquery', 'tinysort'], factory);
    } else if (jQuery && !jQuery.fn.tsort) {
        factory(jQuery, tinysort);
    }
}(function ($, tinysort) {
    'use strict';
    $.tinysort = { defaults: tinysort.defaults };
    $.fn.extend({
        tinysort: function () {
            var aArg = Array.prototype.slice.call(arguments)
				, aSorted, iSorted;
            aArg.unshift(this);
            aSorted = tinysort.apply(null, aArg);
            iSorted = aSorted.length;
            for (var i = 0, l = this.length; i < l; i++) {
                if (i < iSorted) this[i] = aSorted[i];
                else delete this[i];
            }
            this.length = iSorted;
            return this;
        }
    });
    $.fn.tsort = $.fn.tinysort;
}));
//#endregion

$.fn.live = function (event, callback) {
    $(document).on(event, $(this).selector, callback);
}

$.fn.visible = function (state) {
    $(this).css('display', state ? 'block' : 'none');
}

$.fn.timeRemove = function (time) {
    var that = this;
    setTimeout(function () {
        $(that).remove();
    }, time);
}

$.fn.cleanObject = function (onlyNull) {
    return $.each(this, function (id, item) {
        if (onlyNull && this[id] == null)
            this[id] = ''
        if(!onlyNull)
            this[id] = ''
    })
};

function LoadDataField(scope) {
    // # DATA FIELD # //
    scope.col_info_bouquet = [{
        halign: 'center',
        valign: 'middle',
        field: 'nombre_tipo_flor',
        title: 'Flower Type'
    }, {
        halign: 'center',
        valign: 'middle',
        field: 'nombre_variedad_flor',
        title: 'Variety'
    }, {
        halign: 'center',
        valign: 'middle',
        field: 'nombre_grado_flor',
        title: 'Grade'
    }, {
        halign: 'center',
        valign: 'middle',
        field: 'nombre_tapa',
        title: 'Lid'
    }, {
        halign: 'center',
        valign: 'middle',
        field: 'cantidad_piezas',
        title: 'Pieces',
        align: 'center'
    }, {
        valign: 'middle',
        halign: 'center',
        field: 'nombre_tipo_caja',
        title: 'Box'
    }, {
        halign: 'center',
        valign: 'middle',
        field: 'unidades',
        title: 'Pack',
        align: 'center'
    }, {
        halign: 'center',
        valign: 'middle',
        field: 'marca',
        title: 'Code'
    }, {
        align: 'center',
        halign: 'center',
        valign: 'middle',
        field: 'imagen',
        title: 'Image',
        formatter: function (value, row) {
            return ['<img id="img" src="data:image/jpeg;base64,' + row.imagen + '" style="height: 55px; width: 70px;" />']
        }
    }, {
        halign: 'center',
        valign: 'middle',
        field: 'precio_miami_pieza',
        title: 'Average Price',
        align: 'center'
    }, {
        align: 'center',
        halign: 'center',
        valign: 'middle',
        field: 'ethyblock_sachet',
        title: 'Ethy. Sachet',
        formatter: function (value, row) {
            return value ? 'Yes' : 'No'
        }
    }, {
        halign: 'center',
        valign: 'middle',
        field: 'item_number',
        title: 'Item Number',
        align: 'center'
    }, {
        halign: 'center',
        valign: 'middle',
        field: 'nombre_farm',
        title: 'Farm'
    }];

    scope.col_table_bouquet = [{
        halign: 'center',
        field: 'nombre_formula_bouquet',
        title: 'Name',
    }, {
        align: 'center',
        halign: 'center',
        field: 'unidades',
        title: 'Bunches'
    }, {
        halign: 'center',
        align: 'center',
        formatter: function (value, row) {
            if (row.footer)
                return [];
            else
                return ['<span id="spShowRecipe" class="glyphicon glyphicon-th-list"></span>'];                
        },
        events: {
            'mouseover #spShowRecipe': function (e, value, row, index) {
                $(this).popover({
                    animation: false,
                    html: true,
                    placement: 'auto',
                    trigger: 'manual',
                    content: function () {
                        var dataBouquet = {};
                        var totalStems = 0;
                        scope.dataDetailBouquet.id_detalle_version_bouquet = row.id_detalle_version_bouquet;
                        scope.LoadBouquetRecipe(true, false);

                        $.each(scope.dataBouquetRecipe, function (id, item) {
                            totalStems += item.cantidad_tallos
                        });
                        dataBouquet = $.extend(true, dataBouquet, scope.dataBouquetRecipe);
                        dataBouquet = $(dataBouquet).cleanObject();
                        dataBouquet.cantidad_tallos = totalStems;
                        dataBouquet.nombre_tipo_flor = '';
                        dataBouquet.nombre_variedad_flor = '';
                        dataBouquet.nombre_grado_flor = '<strong>Total</strong>';
                        dataBouquet.observacion = '';
                        dataBouquet.nombre_tipo_flor_sustitucion = '';
                        dataBouquet.nombre_variedad_flor_sustitucion = '';
                        dataBouquet.nombre_grado_flor_sustitucion = '';
                        dataBouquet.footer = true;
                        scope.dataBouquetRecipe.push(dataBouquet);

                        var $table = $('<table></table>').bootstrapTable({
                            data: scope.dataBouquetRecipe,
                            columns: scope.col_table_bouquet_recipe_view,
                            rowStyle: function (row, index) {
                                if (row.footer)
                                    return {
                                        classes: 'success'
                                    };
                                else
                                    return {};
                            }
                        });
                        return $table[0].outerHTML;
                    }
                });
                $(this).popover('show');
            },
            'mouseout #spShowRecipe': function () {
                $(this).popover('hide');
            }
        }
    }, {
        halign: 'center',
        align: 'center',
        formatter: function (value, row) {
            if (row.footer)
                return [];
            else
                return ['<span id="spLoadDetail" class="glyphicon glyphicon-repeat"></span>'];                
        },
        events: {
            'click #spLoadDetail': scope.LoadDataDetailBouquet
        }
    }, {
        halign: 'center',
        align: 'center',
        formatter: function (value, row) {
            if (row.footer)
                return [];
            else
                return ['<span id="spDeleteRecipe" class="glyphicon glyphicon-remove"></span>']
        },
        events: {
            'click #spDeleteRecipe': scope.RemoveBouquet
        }
    }];

    scope.col_table_sleeve = [{
        halign: 'center',
        field: 'nombre_capuchon',
        title: 'Name'
    }, {
        halign: 'center',
        valign: 'middle',
        align: 'center',
        field: 'id_capuchon_cultivo',
        formatter: function () {
            return ['<span id="spRemoveSleeve" class="glyphicon glyphicon-remove"></span>']
        },
        events: {
            'click #spRemoveSleeve': scope.RemoveSleeve
        }
    }];

    scope.col_table_sticker = [{
        halign: 'center',
        field: 'nombre_sticker',
        title: 'Name'
    }, {
        valign: 'middle',
        align: 'center',
        field: 'id_sticker',
        formatter: function () {
            return ['<span id="spRemoveSticker" class="glyphicon glyphicon-remove"></span>']
        },
        events: {
            'click #spRemoveSticker': scope.RemoveSticker
        }
    }];

    scope.col_table_form_OP3 = [{
        field: 'nombre_flor',
        title: 'Flower'
    }, {
        field: 'cantidad_tallos',
        title: 'Stems'
    }];

    scope.col_table_bouquet_recipe = [{
        field: 'nombre_tipo_flor',
        title: 'Flower Type',
        formatter: function (value, row, index) {
            if (row.nombre_tipo_flor)
                return ['<div class="input-group" style="max-width:250px;"><span id="spBuncheDetail" class="glyphicon glyphicon-info-sign input-group-addon" style="min-width: 30px;"></span><input type="text" id="txtFlowerType" value="' + row.nombre_tipo_flor + '" class="form-control" /></div>'];
            else
                return ['<input type="text" id="txtFlowerType" value="' + row.nombre_tipo_flor + '" class="form-control" />'];
        },
        events: {
            'focus #txtFlowerType': scope.CreateAutoFlowerType,
            'blur #txtFlowerType': scope.ValidateRecipe,
            'click #spBuncheDetail': scope.OpenModalSearch
        }
    }, {
        field: 'nombre_variedad_flor',
        title: 'Variety',
        formatter: function (value, row) {
            return ['<input type="text" id="txtFlowerVariety" value="' + row.nombre_variedad_flor + '" class="form-control" />']
        },
        events: {
            'focus #txtFlowerVariety': scope.CreateAutoFlowerVariety,
            'blur #txtFlowerVariety': scope.ValidateRecipe
        }
    }, {
        field: 'nombre_grado_flor',
        title: 'Grade',
        formatter: function (vale, row) {
            return ['<input type="text" id="txtFlowerGrade" value="' + row.nombre_grado_flor + '" class="form-control" />']
        },
        events: {
            'focus #txtFlowerGrade': scope.CreateAutoFlowerGrade,
            'blur #txtFlowerGrade': scope.ValidateRecipe
        }
    }, {
        align: 'center',
        field: 'cantidad_tallos',
        title: 'Stems&nbsp;<span class="badge"></span>',
        formatter: function (vale, row) {
            return ['<input type="text" id="txtBunches" value="' + row.cantidad_tallos + '" class="form-control" />']
        },
        events: {
            'keyup #txtBunches': scope.SetValueBouncheRecipe,
            'blur #txtBunches': scope.ValidateRecipe
        }
    }, {
        field: 'observacion',
        title: 'Observation',
        formatter: function (vale, row) {
            return ['<input type="text" id="txtObservation" value="' + row.observacion + '" class="form-control" />']
        },
        events: {
            'blur #txtObservation': function (e, value, row, index) {
                row.observacion = this.value;
                scope.InsertObservation();
            }
        }
    }, {
        field: 'nombre_tipo_flor_sustitucion',
        title: 'Flower Type Substitution',
        formatter: function (vale, row) {
            return ['<input type="text" id="txtFlowerTypeSus" value="' + row.nombre_tipo_flor_sustitucion + '" class="form-control" />']
        },
        events: {
            'focus #txtFlowerTypeSus': scope.CreateAutoFlowerTypeSus,
            'blur #txtFlowerTypeSus': scope.InsertObservation
        }
    }, {
        field: 'nombre_variedad_flor_sustitucion',
        title: 'Variety Substitution',
        formatter: function (vale, row) {
            return ['<input type="text" id="txtFlowerVarietySus" value="' + row.nombre_variedad_flor_sustitucion + '" class="form-control" />']
        },
        events: {
            'focus #txtFlowerVarietySus': scope.CreateAutoFlowerVarietySus,
            'blur #txtFlowerVarietySus': scope.InsertObservation
        }
    }, {
        field: 'nombre_grado_flor_sustitucion',
        title: 'Grade Substitution',
        formatter: function (vale, row) {
            return ['<input type="text" id="txtFlowerGradeSus" value="' + row.nombre_grado_flor_sustitucion + '" class="form-control" />']
        },
        events: {
            'focus #txtFlowerGradeSus': scope.CreateAutoFlowerGradeSus,
            'blur #txtFlowerGradeSus': scope.InsertObservation
        }
    }, {
        valign: 'middle',
        align: 'center',
        formatter: function (vale, row) {
            if (row.id_tipo_flor_cultivo)
                return ['<span id="spRemoveRecipe" class="glyphicon glyphicon-remove"></span>'];
            else
                return [];
        },
        events: {
            'click #spRemoveRecipe': scope.RemoveBouquetRecipe
        }
    }];

    scope.col_table_bouquet_recipe_view = [{
        field: 'nombre_tipo_flor',
        title: 'Type'
    }, {
        field: 'nombre_variedad_flor',
        title: 'Variety'
    }, {
        field: 'nombre_grado_flor',
        title: 'Grade'
    }, {
        align: 'center',
        field: 'cantidad_tallos',
        title: 'Stems'
    }, {
        field: 'observacion',
        title: 'Observation'        
    }, {
        field: 'nombre_tipo_flor_sustitucion',
        title: 'Type Sub.'
    }, {
        field: 'nombre_variedad_flor_sustitucion',
        title: 'Variety Sub.'
    }, {
        field: 'nombre_grado_flor_sustitucion',
        title: 'Grade Sub.'
    }];

    scope.col_table_search_bouquet = [{
        formatter: function () {
            return ['<button type="button" id="btnCopyRecipe" class="btn btn-default navbar-btn" aria-label="Left Align"><span id="spCopyRecipe" class="glyphicon glyphicon-copy" ></span>&nbsp;Copy</button>']
        },
        events: {
            'click #btnCopyRecipe': scope.CopyRecipe
        }
    }, {
        field: 'nombre_tipo_flor',
        title: 'Type'
    }, {
        field: 'nombre_variedad_flor',
        title: 'Variety'
    }, {
        field: 'nombre_grado_flor',
        title: 'Grade'
    }];
}

var DefinirReceta = function () {
    var that = this;

    //#region DOM Objects
    this.$tableInfoBouq = $('#tableInfoBouq');
    this.$tbSleeve = $('#tbSleeve');
    this.$tbSticker = $('#tbSticker');
    this.$tbDetFormulaOP3 = $('#tbDetFormulaOP3');
    this.$tbBouquets = $('#tbBouquets');
    this.$tbBouquetRecipe = $('#tbBouquetRecipe');
    this.$btnSearch = $('#btnSearch');
    this.$btnClear = $('#btnClear');
    this.$tbSearchRecipe = $('#tbSearchRecipe');
    this.$tbSearchBouquet = $('#tbSearchBouquet');
    this.$rbFavorites = $('#rbFavorites');
    this.$rbNewRecipe = $('#rbNewRecipe');
    this.$txtName = $('#txtName');
    this.$txtaSpecs = $('#txtaSpecs');
    this.$txtaConstruction = $('#txtaConstruction');
    this.$txtBunches = $('#txtBunches');
    this.$txtMiamiPrice = $('#txtMiamiPrice');
    this.$txtSleeve = $('#txtSleeve');
    this.$txtSticker = $('#txtSticker');
    this.$txtFood = $('#txtFood');
    this.$pnlUPC = $('#pnlUPC');
    this.$txtUPC = $('#txtUPC');
    this.$txtDescripcionUPC = $('#txtDescripcionUPC');
    this.$txtPrecioUPC = $('#txtPrecioUPC');
    this.$txtFechaUPC = $('#txtFechaUPC');
    this.$txtFormatoUPC = $('#txtFormatoUPC');
    this.$txtBouquetDesc = $('#txtBouquetDesc');
    this.$txtRecipeDesc = $('#txtRecipeDesc');
    this.$txtTextSearch = $('#txtTextSearch');
    this.$mdSearchRecipe = $('#mdSearchRecipe');
    this.$mdSearchBouquet = $('#mdSearchBouquet');
    this.$btnAdd = $('#btnAdd');
    this.$btnSelectAll = $('#btnSelectAll');
    this.$btnSelAllCriterio = $('#btnSelAllCriterio');
    this.$btnSaveAll = $('#btnSaveAll');
    this.$btnClear = $('#btnClear');
    this.$btnSearchRecipe = $('#btnSearchRecipe');
    this.$btnSearchBouquet = $('#btnSearchBouquet');
    this.$btnCopySearch = $('#btnCopySearch');
    this.$btnBack = $('#btnBack');
    this.$selBouqDesc = $('#selBouqDesc');
    this.$selBouqRecipe = $('#selBouqRecipe');
    this.$selParametros = $('#selParametros');
    this.$dvNotification = $('#dvNotification')
    //#endregion //

    //#region DATA
    this.dataSleeve = [];
    this.dataTableSleeve = [];
    this.dataSticker = [];
    this.dataTableSticker = [];
    this.dataFood = [];
    this.dataFormatoUPC = [];
    this.dataFlowerType = [];
    this.dataFlowerGrade = [];
    this.dataDetailPO = [];
    this.dataBouquet = [];
    this.dataBouquetRecipe = [];
    this.dataDetailBouquet = []; //Datos de Ramo, UPC
    this.dataSearchRecipe = [];
    //#endregion

    //#region Fields
    this.col_info_bouquet = [];
    this.col_table_bouquet = [];
    this.col_table_sleeve = [];
    this.col_table_sticker = [];
    this.col_table_form_OP3 = [];
    this.col_table_bouquet_recipe = [];
    this.col_table_search_recipe = [];
    //#endregion

    this.id_comida_bouquet = 0;
    this.id_formato_upc = 0;
    this.id_formula_bouquet = 0;
    this.disabled = 0;
    this.indexRowBouquet = 0;

    this.regExp = {
        emptyWs: /^[\w]+$/,
        empty: /\S/,
        numeric: /[0-9]/g,
        noNumeric: /[^0-9]/g
    }

    this.aux = {
        nullOrEmpty : function (value) {
            return value != null ? (that.regExp.emptyWs.test(value) ? true : false) : false 
        },
        isNumeric: function (value) {
            return that.regExp.numeric.test(value);
        },
        notification: function (principal, description, type) {
            $('.alert-floating ul').empty();
            $('<li><div class="alert alert-' + type + '"><strong>' + principal + '</strong>&nbsp;<span>' + description + '</span></div></li>')
                .css('display', 'block')
                .appendTo('.alert-floating ul')
                .timeRemove(4000);
        },
        getQueryVariable: function(variable)
        {
            var query = window.location.search.substring(1);
            var vars = query.split("&");
            for (var i=0;i<vars.length;i++) {
                var pair = vars[i].split("=");
                if (pair[0] == variable)
                {
                    return pair[1];
                }
            }
            return '';
        }
    }

    this.Init = function () {
        // Load Functions //
        this.LoadDataField(this);
        this.LoadDetailPO();

        // Bouquet Type //
        this.$txtaSpecs.on('blur', function () {
            if (that.dataDetailBouquet.id_detalle_version_bouquet != undefined && that.dataDetailBouquet.id_detalle_version_bouquet != 0) {
                that.InsertBasicBouquetDescription();
                that.LoadBouquets();
            }
        });
        this.$txtaConstruction.on('blur', function () {
            if (that.dataDetailBouquet.id_detalle_version_bouquet != undefined && that.dataDetailBouquet.id_detalle_version_bouquet != 0) {
                that.InsertBasicBouquetDescription();
                that.LoadBouquets();
            }
        });
        this.$txtBunches.on('blur', function () {
            if (this.value <= 0) {
                that.aux.notification('Recipe: ', 'Insert a value greater than 0', 'info');
                this.value = '';
                return;
            }
            if (that.dataDetailBouquet.id_detalle_version_bouquet != undefined && that.dataDetailBouquet.id_detalle_version_bouquet != 0) {
                that.InsertBasicBouquetDescription();
                that.LoadBouquets();
            }
        });
        this.$txtMiamiPrice.on('blur', function () {
            if (that.dataDetailBouquet.id_detalle_version_bouquet != undefined && that.dataDetailBouquet.id_detalle_version_bouquet != 0) {
                that.InsertBasicBouquetDescription();
                that.LoadBouquets();
            }
        });

        // UPC //
        this.$txtUPC.on({
            'keyup': function (e) {
                if ((e.keyCode >= 48 && e.keyCode <= 57) || (e.keyCode >= 96 && e.keyCode <= 105) || e.keyCode == 8 || e.keyCode == 46 || e.keyCode == 37 || e.keyCode == 39) {
                    that.CalculateCheckDigit();
                } else {
                    this.value = this.value.replace(that.regExp.noNumeric, '');
                }
            },
            'blur': function () {
                $(this).popover('hide');
                if (this.value.length == 11 || this.value.length == 0)
                    that.InsertUPC();
                else
                    that.aux.notification('UPC', 'UPC number require 11 digits.', 'warning')
            }
        });
        this.$txtDescripcionUPC.on('blur', function () {
            that.InsertUPC();
        });
        this.$txtPrecioUPC.on('blur', function () {
            that.InsertUPC();
        });
        this.$txtFormatoUPC.on('blur', function () {
            if (this.value == '')
                that.id_formato_upc = 0;
            that.$txtFormatoUPC.popover('hide');
        });
        this.$txtFechaUPC.on('blur', function () {
            that.InsertUPC();
        });

        // Autocomplete //
        this.$txtFormatoUPC.autocomplete({
            position: { my: "left top", at: "left bottom" },
            source: function (request, response) {
                that.LoadFormatoUPC(request.term)
                response(that.dataFormatoUPC)
            },
            select: function (event, ui) {
                event.preventDefault();
                this.value = ui.item.label;
                that.id_formato_upc = ui.item.value == null ? 0 : ui.item.value;

                if (ui.item.label == 'ESPECIAL' || ui.item.label == '2 LINEAS DE DESCRIPCION') {
                    that.$txtFormatoUPC.attr('data-content', "Please enter upc comment in specifications 'Specs' field.");
                    that.$txtFormatoUPC.popover('show');
                }

                that.DisableUPC(ui.item.label);

                if (that.dataDetailBouquet.id_detalle_version_bouquet != undefined && that.dataDetailBouquet.id_detalle_version_bouquet != 0) {
                    that.InsertBasicBouquetDescription();
                    that.LoadBouquets();
                }
            },
            focus: function (event, ui) {
                event.preventDefault();
                this.value = ui.item.label;
            }
        });
        this.$txtSleeve.autocomplete({
            position: { my: "left top", at: "left bottom" },
            source: function (request, response) {
                that.LoadDataSleeve(request.term)
                response(that.dataSleeve)
            },
            select: function (event, ui) {
                event.preventDefault();
                this.value = '';
                that.InsertSleeve(ui.item);
            },
            focus: function (event, ui) {
                event.preventDefault();
                this.value = ui.item.label;
            }
        });
        this.$txtSticker.autocomplete({
            position: { my: "left top", at: "left bottom" },
            source: function (request, response) {
                that.LoadDataSticker(request.term)
                response(that.dataSticker)
            },
            select: function (event, ui) {
                event.preventDefault();
                this.value = '';
                that.InsertSticker(ui.item);
            },
            focus: function (event, ui) {
                event.preventDefault();
                this.value = ui.item.label;
            }
        });
        this.$txtFood.autocomplete({
            position: { my: "left top", at: "left bottom" },
            source: function (request, response) {
                that.LoadFood(request.term)
                response(that.dataFood)
            },
            select: function (event, ui) {
                event.preventDefault();
                this.value = ui.item.label;
                that.id_comida_bouquet = ui.item.value;
                if (that.dataDetailBouquet.id_detalle_version_bouquet != undefined && that.dataDetailBouquet.id_detalle_version_bouquet != 0) {
                    that.InsertBasicBouquetDescription();
                    that.LoadBouquets();
                }
            },
            focus: function (event, ui) {
                event.preventDefault();
                this.value = ui.item.label;
            }
        });

        //#region Inicializar Bootstrap Table //
        this.$tbSleeve.bootstrapTable({
            classes: 'table',
            columns: that.col_table_sleeve
        });
        this.$tbSleeve.bootstrapTable('hideLoading');
        this.$tbDetFormulaOP3.bootstrapTable({
            classes: 'table',
            columns: that.col_table_form_OP3
        });
        this.$tbDetFormulaOP3.bootstrapTable('hideLoading');
        this.$tbBouquetRecipe.bootstrapTable({
            columns: that.col_table_bouquet_recipe
        });
        this.$tbBouquetRecipe.bootstrapTable('hideLoading');
        this.$tbSticker.bootstrapTable({
            classes: 'table',
            columns: that.col_table_sticker
        });
        this.$tbSticker.bootstrapTable('hideLoading');
        this.$tbBouquets.bootstrapTable({
            classes: 'table',
            columns: that.col_table_bouquet,
            rowStyle: function (row, index) {
                if (row.footer)
                    return {
                        classes: 'success'
                    };
                else
                    return {};
            }
        })
        this.$tbBouquets.bootstrapTable('hideLoading');
        this.$tbSearchBouquet.bootstrapTable({
            classes: 'table',
            columns: that.col_table_search_bouquet
        });
        this.$tbSearchBouquet.bootstrapTable('hideLoading');
        //#endregion

        // Sortable //
        this.$pnlUPC.sortable({
            cursor: 'move',
            start: function (event, ui) {
                console.log('antes: ' + ui.item.index())
            },
            update: function (event, ui) {
                that.InsertUPC();
            },
            opacity: 0.7
        });

        //Cargar datos de tabla de bouquets//
        this.LoadBouquets();

        //Popover
        this.$txtUPC.popover({
            trigger: 'manual',
            html: true
        });

        this.$txtFormatoUPC.popover({
            trigger: 'manual',
            html: true
        });

        //Modal Search//
        this.$mdSearchRecipe.on('hidden.bs.modal', function () {
            that.$tbSearchRecipe.bootstrapTable('destroy');
        });

        this.$btnBack.on('click', function () {
            window.history.back(); 
        });

        this.$btnSelectAll.on('click', function (e) {
            that.$selBouqDesc.find('option').prop('selected', true);
            that.$selBouqRecipe.find('option').prop('selected', true);
        });

        this.$btnSelAllCriterio.on('click', function (e) {
            that.$selParametros.find('option').prop('selected', true);
        });

        this.$btnAdd.on('click', function (e) {
            that.dataDetailBouquet.id_detalle_version_bouquet = 0;
            that.InsertAllRecipe();
        });

        this.$btnSaveAll.on('click', function (e) {
            that.InsertAllRecipe();
            if (confirm('All Saved \nYou want go back page?')) {
                window.history.back();
            }            
        });

        this.$btnClear.on('click', function () {
            that.ClearDetailBouquet();
        });

        this.$btnSearchRecipe.on('click', function (e) {
            var bouquetDesc = that.$txtBouquetDesc.val();
            var recipeDesc = that.$txtRecipeDesc.val();
            var arrBouquetFilter = $.map(that.$selBouqDesc.find('option:selected'), function (element, index) {
                return element.value
            });
            var arrRecipeFilter = $.map(that.$selBouqRecipe.find('option:selected'), function (element, index) {
                return element.value
            });

            that.LoadColumnsSearchRecipe(bouquetDesc, arrBouquetFilter.join(), recipeDesc, arrRecipeFilter.join());
            that.LoadSearchRecipe();
        });

        this.$tbSearchRecipe.find('.th-inner').live('click', function () {
            var $th = $(this).parents('th:first')
            that.ClearDetailBouquet();
            that.dataDetailBouquet.id_detalle_version_bouquet = $th.find('#hdfIdDetalle').val();
            that.LoadDataDetailBouquetSelected();
            that.LoadTablaSleeve();
            that.LoadTablaSticker();
            that.$tbSearchRecipe.bootstrapTable('destroy');
            that.$mdSearchRecipe.modal('hide');
        });

        this.$btnSearchBouquet.on('click', function () {
            that.LoadSearchBouquet();
        });
    };

    this.LoadDataField = LoadDataField;

    this.LoadDetailPO = function () {
        var idDetallePO = that.aux.getQueryVariable('idDetalle');
        var po = that.aux.getQueryVariable('po');
        var usuario = that.aux.getQueryVariable('usuario');
        var data = [];

        try {
            data = AjaxQuery2('../../../Old_App_Code/Natuflora/WebService/Bouquets/WSBouquets.asmx', 'ConsultarDetallePO', 'POST', '{"idDetallePO":"' + idDetallePO + '"}');
            that.dataDetailPO = data[0];
        } catch (e) {
            that.aux.notification('Error: ', e.message, 'danger');
        }
            
        that.$tableInfoBouq.bootstrapTable({
            classes: 'table',
            data: data,
            columns: that.col_info_bouquet
        });
        that.$tableInfoBouq.bootstrapTable('hideLoading');
    }
    //Tabla de bouquets//
    this.LoadBouquets = function () {
        var totalBounches = 0;
        var dataBouquet = {};
            
        this.dataBouquet = AjaxQuery2('../../../Old_App_Code/Natuflora/WebService/Bouquets/WSBouquets.asmx', 'ReadBouquets', 'POST', '{ "id_version_bouquet" : ' + that.dataDetailPO.id_version_bouquet + ' }');
        $.each(this.dataBouquet, function (id, item) {
            totalBounches += item.unidades
        });

        dataBouquet = $.extend(true, dataBouquet, this.dataBouquet[0]);
        dataBouquet = $(dataBouquet).cleanObject();
        dataBouquet.unidades = totalBounches;
        dataBouquet.nombre_formula_bouquet = '<strong>Total</strong>';
        dataBouquet.footer = true;
        that.dataBouquet.push(dataBouquet);
        that.$tbBouquets.bootstrapTable('load', this.dataBouquet);

        //Carga el detalle del primer bouquet//
        this.$tbBouquets.find('[id*=spLoadDetail]:eq(' + that.indexRowBouquet + ')').trigger('click');
    }

    this.LoadDataDetailBouquet = function (e, value, row, index) {
        that.indexRowBouquet = index;
        that.$tbBouquets.find('tr').removeClass('tr-selected');
        that.$tbBouquets.find('tr:eq(' + (index + 1) + ')').addClass('tr-selected');
        
        that.id_formula_bouquet = row.id_formula_bouquet;
        that.ClearDetailBouquet();
        var data = AjaxQuery2('../../../Old_App_Code/Natuflora/WebService/Bouquets/WSBouquets.asmx', 'ReadDetailBouquet', 'POST', '{ "id_version_bouquet" : ' + that.dataDetailPO.id_version_bouquet + ', "id_formula_bouquet": ' + row.id_formula_bouquet + ' }');
        if (data.length > 0) {
            that.dataDetailBouquet = data[0];
            that.SetDataDetailBouquet();
            that.LoadUPC();
            that.DisableUPC(that.$txtFormatoUPC.val());
            that.SortUPC();
            that.LoadTablaSleeve();
            that.LoadTablaSticker();
            that.LoadBouquetRecipe(false, true);
            
            if (that.dataDetailPO.id_status) {
                that.LoadDetailFormulaOP3();
            }
            that.DisabledDOM();
            that.aux.notification('', 'Detail recipe loaded', 'info');
        }
    }

    this.SetDataDetailBouquet = function () {
        that.$txtName.val(that.dataDetailBouquet.nombre_formula_bouquet);
        that.$txtaSpecs.val(that.dataDetailBouquet.especificacion_bouquet);
        that.$txtaConstruction.val(that.dataDetailBouquet.construccion_bouquet);
        that.$txtBunches.val(that.dataDetailBouquet.unidades);
        that.$txtMiamiPrice.val(that.dataDetailBouquet.precio_miami);
        that.$txtFood.val(that.dataDetailBouquet.nombre_comida);
        that.id_comida_bouquet = that.dataDetailBouquet.id_comida_bouquet;
    }

    this.LoadDataDetailBouquetSelected = function () {
        var data = AjaxQuery2('../../../Old_App_Code/Natuflora/WebService/Bouquets/WSBouquets.asmx', 'ReadDetailBouquetSelected', 'POST', '{ "id_detalle_version_bouquet" : ' + that.dataDetailBouquet.id_detalle_version_bouquet + ' }');
        that.dataBouquet = data[0][0];
        that.dataDetailBouquet = data[1];
        that.dataDetailBouquet.id_detalle_version_bouquet = data[1][0].id_detalle_version_bouquet;
        that.SetDataDetailBouquetSelected();
        that.LoadBouquetRecipeSelected();
        that.CountStems();
    }

    this.SetDataDetailBouquetSelected = function () {
        that.$txtName.val(that.dataBouquet.nombre_formula_bouquet);
        that.$txtaSpecs.val(that.dataBouquet.especificacion_bouquet);
        that.$txtaConstruction.val(that.dataBouquet.construccion_bouquet);
        that.$txtBunches.val(that.dataDetailBouquet[0].unidades);
        that.$txtMiamiPrice.val(that.dataDetailBouquet[0].precio_miami);
        that.$txtFood.val(that.dataDetailBouquet[0].nombre_comida);
        that.id_comida_bouquet = that.dataDetailBouquet[0].id_comida_bouquet;
        that.$txtUPC.val(that.dataDetailBouquet[0].upc);
        that.$txtDescripcionUPC.val(that.dataDetailBouquet[0].descripcion_upc);
        that.$txtPrecioUPC.val(that.dataDetailBouquet[0].precio_upc);
        that.$txtFechaUPC.val(that.dataDetailBouquet[0].fecha_upc);
    }

    //#region Sleeve
    this.LoadTablaSleeve = function () {
        that.dataTableSleeve = AjaxQuery2('../../../Old_App_Code/Natuflora/WebService/Bouquets/WSBouquets.asmx', 'ReadTablaSleeve', 'POST', '{ "id_detalle_version_bouquet" : ' + that.dataDetailBouquet.id_detalle_version_bouquet + '}');
        that.$tbSleeve.bootstrapTable('load', this.dataTableSleeve);
    }

    this.LoadDataSleeve = function (find) {
        var data = AjaxQuery2('../../../Old_App_Code/Natuflora/WebService/Bouquets/WSBouquets.asmx', 'ReadSleeve', 'POST', '{"nombre_capuchon":"' + find + '"}');
        this.dataSleeve = $.map(data, function (item) {
            return {
                label: item.nombre_capuchon,
                value: item.id_capuchon_cultivo
            }
        });
    }

    this.InsertSleeve = function (item) {
        if (that.dataDetailBouquet.id_detalle_version_bouquet === undefined || that.dataDetailBouquet.id_detalle_version_bouquet == 0) {
            that.$tbSleeve.bootstrapTable('append', { id_capuchon_cultivo: item.value, nombre_capuchon: item.label });
        } else {
            var data = AjaxQuery2('../../../Old_App_Code/Natuflora/WebService/Bouquets/WSBouquets.asmx', 'InsertSleeve', 'POST', '{ "id_capuchon_cultivo" : "' + item.value + '", "id_detalle_version_bouquet": ' + that.dataDetailBouquet.id_detalle_version_bouquet + ' }');
            if (data[0].response > 0) {
                that.LoadTablaSleeve();
                that.aux.notification('Sleeve: ', 'Sleeve inserted', 'success');
            }
        }
    }

    this.RemoveSleeve = function (e, value, row, index) {
        if (that.dataDetailBouquet.id_detalle_version_bouquet === undefined || that.dataDetailBouquet.id_detalle_version_bouquet == 0) {
            that.$tbSleeve.bootstrapTable('remove', {
                field: 'id_capuchon_cultivo',
                values: [row.id_capuchon_cultivo]
            });
        } else {
            var dataExist = that.$tbSleeve.bootstrapTable('getData');
            if (dataExist.length <= 1)
                return;
            var data = AjaxQuery2('../../../Old_App_Code/Natuflora/WebService/Bouquets/WSBouquets.asmx', 'RemoveSleeve', 'POST', '{ "id_capuchon_cultivo" : ' + row.id_capuchon_cultivo + ', "id_detalle_version_bouquet": ' + that.dataDetailBouquet.id_detalle_version_bouquet + ' }');
            if (data[0].responseMessage == '_removed') {
                that.LoadTablaSleeve();
                that.aux.notification('Sleeve: ', 'Sleeve removed', 'success');
            }
        }
    }
    //#endregion

    //#region Sticker //
    this.LoadTablaSticker = function () {
        //that.id_detalle_version_bouquet = this.dataDetailBouquet.id_detalle_version_bouquet || that.id_detalle_version_bouquet;
        that.dataTableSticker = AjaxQuery2('../../../Old_App_Code/Natuflora/WebService/Bouquets/WSBouquets.asmx', 'ReadTablaSticker', 'POST', '{ "id_detalle_version_bouquet" : ' + that.dataDetailBouquet.id_detalle_version_bouquet + '}');
        that.$tbSticker.bootstrapTable('load', that.dataTableSticker);
    }

    this.LoadDataSticker = function (find) {
        var data = AjaxQuery2('../../../Old_App_Code/Natuflora/WebService/Bouquets/WSBouquets.asmx', 'ReadSticker', 'POST', '{"nombre_sticker":"' + find + '"}');
        that.dataSticker = $.map(data, function (item) {
            return {
                label: item.nombre_sticker,
                value: item.id_sticker
            }
        });
    }

    this.InsertSticker = function (item) {
        if (that.dataDetailBouquet.id_detalle_version_bouquet === undefined || that.dataDetailBouquet.id_detalle_version_bouquet == 0) {
            that.$tbSticker.bootstrapTable('append', { id_sticker: item.value, nombre_sticker: item.label });
        } else {
            var data = AjaxQuery2('../../../Old_App_Code/Natuflora/WebService/Bouquets/WSBouquets.asmx', 'InsertSticker', 'POST', '{ "id_sticker" : "' + item.value + '", "id_detalle_version_bouquet": ' + that.dataDetailBouquet.id_detalle_version_bouquet + ' }');
            if (data[0].response > 0) {
                that.LoadTablaSticker();
                that.aux.notification('Sticker: ', 'Sticker inserted', 'success');
            }
        }
    }

    this.RemoveSticker = function (e, value, row, index) {
        if (that.dataDetailBouquet.id_detalle_version_bouquet === undefined || that.dataDetailBouquet.id_detalle_version_bouquet == 0) {
            that.$tbSticker.bootstrapTable('remove', {
                field: 'id_sticker',
                values: [row.id_sticker]
            });
        } else {
            var data = AjaxQuery2('../../../Old_App_Code/Natuflora/WebService/Bouquets/WSBouquets.asmx', 'RemoveSticker', 'POST', '{ "id_sticker" : ' + row.id_sticker + ', "id_detalle_version_bouquet": ' + that.dataDetailBouquet.id_detalle_version_bouquet + ' }');
            if (data[0].responseMessage == '_removed') {
                that.LoadTablaSticker();
                that.aux.notification('Sticker', 'Sticker removed', 'success');
            }
        }
    }
    //#endregion

    this.LoadFood = function (find) {
        var data = AjaxQuery2('../../../Old_App_Code/Natuflora/WebService/Bouquets/WSBouquets.asmx', 'ReadFood', 'POST', '{"nombre_comida_bouquet":"' + find + '"}');
        this.dataFood = $.map(data, function (item) {
            return {
                label: item.nombre_comida_bouquet,
                value: item.id_comida_bouquet
            }
        });
    }

    this.LoadFormatoUPC = function (find) {
        var data = AjaxQuery2('../../../Old_App_Code/Natuflora/WebService/Bouquets/WSBouquets.asmx', 'ReadFormatoUPC', 'POST', '{"nombre_formato":"' + find + '"}');
        this.dataFormatoUPC = $.map(data, function (item) {
            return {
                label: item.nombre_formato,
                value: item.id_formato_upc
            }
        });
    }

    //#region Bouquet Recipe//
    this.CreateAutoFlowerType = function (e, value, row, index) {
        $(this).autocomplete({
            source: function (request, response) {
                that.LoadFlowerType(request.term)
                response(that.dataFlowerType)
            },
            select: function (event, ui) {
                event.preventDefault();
                
                var $tr = $(this).parents('tr:first');
                $tr.find('#txtFlowerVariety').val('');
                $tr.find('#txtFlowerGrade').val('');
                this.value = ui.item.label;
                this.title = ui.item.label;
                this.focus();

                row.id_tipo_flor_cultivo = ui.item.value;
                row.nombre_tipo_flor = ui.item.label;
                row.id_variedad_flor_cultivo = ''
                row.nombre_variedad_flor = '';
                row.id_grado_flor_cultivo = ''
                row.nombre_grado_flor = '';
            },
            focus: function (event, ui) {
                event.preventDefault();
                this.value = ui.item.label;
                this.title = ui.item.label;
            }
        });

        $(this).tooltip({
            placement: 'top'
        });
    }

    this.CreateAutoFlowerTypeSus = function (e, value, row, index) {
        $(this).autocomplete({
            source: function (request, response) {
                that.LoadFlowerType(request.term)
                response(that.dataFlowerType)
            },
            select: function (event, ui) {
                event.preventDefault();

                var $tr = $(this).parents('tr:first');
                $tr.find('#txtFlowerVarietySus').val('');
                $tr.find('#txtFlowerGradeSus').val('');
                this.value = ui.item.label;
                this.title = ui.item.label;

                row.id_tipo_flor_cultivo_sustitucion = ui.item.value;
                row.nombre_tipo_flor_sustitucion = ui.item.label;
                row.id_variedad_flor_cultivo_sustitucion = ''
                row.nombre_variedad_flor_sustitucion = '';
                row.id_grado_flor_cultivo_sustitucion = ''
                row.nombre_grado_flor_sustitucion = '';
            },
            focus: function (event, ui) {
                event.preventDefault();
                this.value = ui.item.label;
                this.title = ui.item.label;
            }
        });
    }

    this.CreateAutoFlowerVariety = function (e, value, row, index) {
        $(this).autocomplete({
            source: function (request, response) {
                that.LoadFlowerVariety(request.term, row)
                response(that.dataFlowerVariety)
            },
            select: function (event, ui) {
                event.preventDefault();
                this.value = ui.item.label;
                this.title = ui.item.label;
                this.focus();

                row.id_variedad_flor_cultivo = ui.item.value;
                row.nombre_variedad_flor = ui.item.label;
            },
            focus: function (event, ui) {
                event.preventDefault();
                this.value = ui.item.label;
                this.title = ui.item.label;
            }
        });
    }

    this.CreateAutoFlowerVarietySus = function (e, value, row, index) {
        $(this).autocomplete({
            source: function (request, response) {
                that.LoadFlowerVarietySus(request.term, row)
                response(that.dataFlowerVariety)
            },
            select: function (event, ui) {
                event.preventDefault();
                this.value = ui.item.label;
                this.title = ui.item.label;

                row.id_variedad_flor_cultivo_sustitucion = ui.item.value;
                row.nombre_variedad_flor_sustitucion = ui.item.label;
            },
            focus: function (event, ui) {
                event.preventDefault();
                this.value = ui.item.label;
                this.title = ui.item.label;
            }
        });
    }

    this.CreateAutoFlowerGrade = function (e, value, row, index) {
        $(this).autocomplete({
            source: function (request, response) {
                that.LoadFlowerGrade(request.term, row)
                response(that.dataFlowerGrade)
            },
            select: function (event, ui) {
                event.preventDefault();
                this.value = ui.item.label;
                this.title = ui.item.label;
                this.focus();

                row.id_grado_flor_cultivo = ui.item.value;
                row.nombre_grado_flor = ui.item.label;
            },
            focus: function (event, ui) {
                event.preventDefault();
                this.value = ui.item.label;
                this.title = ui.item.label;
            }                
        });
    }

    this.CreateAutoFlowerGradeSus = function (e, value, row, index) {
        $(this).autocomplete({
            source: function (request, response) {
                that.LoadFlowerGradeSus(request.term, row)
                response(that.dataFlowerGrade)
            },
            select: function (event, ui) {
                event.preventDefault();
                this.value = ui.item.label;
                this.title = ui.item.label;

                row.id_grado_flor_cultivo_sustitucion = ui.item.value;
                row.nombre_grado_flor_sustitucion = ui.item.label;
            },
            focus: function (event, ui) {
                event.preventDefault();
                this.value = ui.item.label;
                this.title = ui.item.label;
            }
        });
    }

    this.LoadFlowerType = function (find) {
        var data = AjaxQuery2('../../../Old_App_Code/Natuflora/WebService/Bouquets/WSBouquets.asmx', 'ReadFlowerType', 'POST', '{ "nombre_tipo_flor" : "' + find + '" }');
        this.dataFlowerType = $.map(data, function (item) {
            return {
                label: item.nombre_tipo_flor.trim(),
                value: item.id_tipo_flor_cultivo
            }
        });
    }

    this.LoadFlowerVariety = function (find, row) {
        var data = AjaxQuery2('../../../Old_App_Code/Natuflora/WebService/Bouquets/WSBouquets.asmx', 'ReadFlowerVariety', 'POST', '{ "id_tipo_flor_cultivo" : ' + row.id_tipo_flor_cultivo + ', "nombre_variedad_flor" : "' + find + '" }');
        this.dataFlowerVariety = $.map(data, function (item) {
            return {
                label: item.nombre_variedad_flor.trim(),
                value: item.id_variedad_flor_cultivo
            }
        });
    }

    this.LoadFlowerVarietySus = function (find, row) {
        var data = AjaxQuery2('../../../Old_App_Code/Natuflora/WebService/Bouquets/WSBouquets.asmx', 'ReadFlowerVariety', 'POST', '{ "id_tipo_flor_cultivo" : ' + row.id_tipo_flor_cultivo_sustitucion + ', "nombre_variedad_flor" : "' + find + '" }');
        this.dataFlowerVariety = $.map(data, function (item) {
            return {
                label: item.nombre_variedad_flor.trim(),
                value: item.id_variedad_flor_cultivo
            }
        });
    }

    this.LoadFlowerGrade = function (find, row) {
        var data = AjaxQuery2('../../../Old_App_Code/Natuflora/WebService/Bouquets/WSBouquets.asmx', 'ReadFlowerGrade', 'POST', '{ "id_tipo_flor_cultivo" : ' + row.id_tipo_flor_cultivo + ', "nombre_grado_flor" : "' + find + '" }');
        this.dataFlowerGrade = $.map(data, function (item) {
            return {
                label: item.nombre_grado_flor.trim(),
                value: item.id_grado_flor_cultivo
            }
        });
    }

    this.LoadFlowerGradeSus = function (find, row) {
        var data = AjaxQuery2('../../../Old_App_Code/Natuflora/WebService/Bouquets/WSBouquets.asmx', 'ReadFlowerGrade', 'POST', '{ "id_tipo_flor_cultivo" : ' + row.id_tipo_flor_cultivo_sustitucion + ', "nombre_grado_flor" : "' + find + '" }');
        this.dataFlowerGrade = $.map(data, function (item) {
            return {
                label: item.nombre_grado_flor.trim(),
                value: item.id_grado_flor_cultivo
            }
        });
    }

    this.ValidateRecipe = function (e, value, row, index) {
        var $row = $(this).parents('tr:first')

        if (!that.aux.nullOrEmpty(row.id_tipo_flor_cultivo))
            $row.find('#txtFlowerType').addClass('validate-fail');
        else
            $row.find('#txtFlowerType').removeClass('validate-fail')
        if (!that.aux.nullOrEmpty(row.id_variedad_flor_cultivo))
            $row.find('#txtFlowerVariety').addClass('validate-fail');
        else
            $row.find('#txtFlowerVariety').removeClass('validate-fail')
        if (!that.aux.nullOrEmpty(row.id_grado_flor_cultivo))
            $row.find('#txtFlowerGrade').addClass('validate-fail');
        else
            $row.find('#txtFlowerGrade').removeClass('validate-fail')

        if (!isNaN(row.cantidad_tallos)) {
            if (row.cantidad_tallos <= 0)
                $row.find('#txtBunches').addClass('validate-fail');
            else
                $row.find('#txtBunches').removeClass('validate-fail')
        } else {
            $row.find('#txtBunches').addClass('validate-fail')
        }
        
        if ($row.find('.validate-fail').length == 0) {
            var arrRecipes = that.$tbBouquetRecipe.bootstrapTable('getData');
            if (that.dataDetailBouquet.id_detalle_version_bouquet != undefined && that.dataDetailBouquet.id_detalle_version_bouquet != 0) {
                that.InsertBasicBouquetDescription();
                that.LoadBouquets();
                that.InsertObservation();
            }
            var empty = $.extend({}, arrRecipes[0]);
            var last = arrRecipes.pop();
            
            empty = $.each(empty, function (id, item) {
                empty[id] = ''
            });
                
            if (last['cantidad_tallos'] > 0 && last['id_tipo_flor_cultivo'] != '' && last['id_variedad_flor_cultivo'] != '' && last['id_grado_flor_cultivo'] != '') {
                arrRecipes.push(last);
                arrRecipes.push(empty);
            } else {
                arrRecipes.push(empty);
            }
            that.$tbBouquetRecipe.bootstrapTable('load', arrRecipes);
            that.CountStems();
        }
    }
    //#endregion

    this.LoadDetailFormulaOP3 = function () {
        var data = AjaxQuery2('../../../Old_App_Code/Natuflora/WebService/Bouquets/WSBouquets.asmx', 'ReadDetailFormulaOP3', 'POST', '{ "id_detalle_version_bouquet" : ' + this.dataDetailBouquet.id_detalle_version_bouquet + '}');
        this.$tbDetFormulaOP3.bootstrapTable('load', data);
    }

    this.RemoveBouquet = function (e, value, row, index) {
        if (confirm('Really you want to delete the recipe?')) {
            that.indexRowBouquet = 0;
            var data = AjaxQuery2('../../../Old_App_Code/Natuflora/WebService/Bouquets/WSBouquets.asmx', 'RemoveRecipe', 'POST', '{ "id_detalle_version_bouquet": ' + row.id_detalle_version_bouquet + ' }');
            if (data[0].responseMessage == '_removed') {
                that.ClearDetailBouquet();
                that.LoadBouquets();
            }
        }
    }

    this.LoadBouquetRecipe = function (onlyData, emptyRow) {
        that.dataBouquetRecipe = AjaxQuery2('../../../Old_App_Code/Natuflora/WebService/Bouquets/WSBouquets.asmx', 'ReadBouquetRecipe', 'POST', '{ "id_detalle_version_bouquet" : ' + that.dataDetailBouquet.id_detalle_version_bouquet + ', "getModel" : false, "emptyRow" : ' + emptyRow + ' }');
        if (!onlyData)
            this.$tbBouquetRecipe.bootstrapTable('load', that.dataBouquetRecipe);

        that.CountStems();
    }

    this.RemoveBouquetRecipe = function (e, value, row, index) {
        var arrData = that.$tbBouquetRecipe.bootstrapTable('getData');
        var rowCount = arrData.length;
        if (arrData.length > 2)
            arrData.splice(index, 1);

        that.$tbBouquetRecipe.bootstrapTable('load', arrData);
        if (that.dataDetailBouquet.id_detalle_version_bouquet != undefined && that.dataDetailBouquet.id_detalle_version_bouquet != 0 && rowCount > 2) {
            that.InsertBasicBouquetDescription();
            that.LoadBouquets();
            that.aux.notification('Recipe: ', 'Recipe removed', 'success');
        }
    }

    this.LoadBouquetRecipeSelected = function () {
        this.$tbBouquetRecipe.bootstrapTable('load', that.dataDetailBouquet);
    }

    this.LoadUPC = function () {
        this.$txtUPC.val(this.dataDetailBouquet.upc);
        this.$txtUPC.parents('div:first').attr('data-orden', this.dataDetailBouquet.orden_upc);
        this.$txtDescripcionUPC.val(this.dataDetailBouquet.descripcion_upc);
        this.$txtDescripcionUPC.parents('div:first').attr('data-orden', this.dataDetailBouquet.orden_descripcion_upc);
        this.$txtPrecioUPC.val(this.dataDetailBouquet.precio_upc);
        this.$txtPrecioUPC.parents('div:first').attr('data-orden', this.dataDetailBouquet.orden_precio_upc);
        this.$txtFechaUPC.val(this.dataDetailBouquet.fecha_upc);
        this.$txtFechaUPC.parents('div:first').attr('data-orden', this.dataDetailBouquet.orden_fecha_upc);
        this.$txtFormatoUPC.val(this.dataDetailBouquet.nombre_formato);
        this.id_formato_upc = this.dataDetailBouquet.id_formato_upc;
        that.CalculateCheckDigit();
    }

    this.InsertUPC = function () {
        var objUPC = $.map(that.$pnlUPC.find('div'), function (value, key) {
            return {
                descripcion_upc: $(value).find('input[type="text"]').val(),
                orden_upc: key,
                nombre_informacion_upc: $(value).attr('id')
            }
        });
        AjaxQuery2('../../../Old_App_Code/Natuflora/WebService/Bouquets/WSBouquets.asmx', 'InsertUPC', 'POST', '{"upc": ' + JSON.stringify(objUPC) + ', "id_detalle_version_bouquet":' + that.dataDetailBouquet.id_detalle_version_bouquet + '}');
    }

    this.SortUPC = function () {
        that.$pnlUPC.find('div').tsort({ attr: 'data-orden' });            
    }

    this.LoadColumnsSearchRecipe = function (texto, items_a_buscar, texto2, items_a_buscar2) {
        //Columnas Dinamicas//
        this.$tbSearchRecipe.bootstrapTable('destroy');
        this.dataSearchRecipe = AjaxQuery2('../../../Old_App_Code/Natuflora/WebService/Bouquets/WSBouquets.asmx', 'ReadSearchRecipe', 'POST', '{"texto": "' + texto + '", "items_a_buscar": "' + items_a_buscar + '", "texto2": "' + texto2 + '", "items_a_buscar2": "' + items_a_buscar2 + '"}');
            
        this.col_table_search_recipe = $.map(that.dataSearchRecipe[0], function (value, key) {                
            return {
                field: key,
                title: key == 'nombre_flor' ? 'Flower Name' : key.split('-')[1] + '<input type="hidden" id="hdfIdDetalle" value="' + key.split('-')[0].trim() + '"/>'
            };
        });
            
        this.$tbSearchRecipe.bootstrapTable({
            cache: false,
            columns: that.col_table_search_recipe,
            data: that.dataSearchRecipe
        });

        this.$tbSearchRecipe.bootstrapTable('hideLoading');
    }

    this.LoadSearchRecipe = function () {
        this.$tbSearchRecipe.bootstrapTable('load', this.dataSearchRecipe);
    }

    this.InsertAllRecipe = function () {
        var arrSleeve = $.map(this.$tbSleeve.bootstrapTable('getData'), function (value, key) {
            return value.id_capuchon_cultivo
        });

        var arrBouquetRecipe = that.$tbBouquetRecipe.bootstrapTable('getData');

        // Validacion //
        if (arrSleeve.length <= 0) {
            that.aux.notification('Sleeve: ', 'Sleeve is required', 'warning');
            return;
        }

        if (!that.regExp.empty.test(arrBouquetRecipe[0].id_tipo_flor_cultivo)) {
            that.aux.notification('Bouquet Information:', 'Require at least one', 'warning');
            return;
        }

        if (!that.regExp.empty.test(that.$txtName.val())) {
            that.aux.notification('Bouquet Description:', 'Name is required', 'warning');
            return;
        }

        if (!that.regExp.empty.test(that.$txtMiamiPrice.val())) {
            that.aux.notification('Bouquet Description:', 'Price is required', 'warning');
            return;
        }

        if (!that.regExp.empty.test(that.$txtBunches.val())) {
            that.aux.notification('Bouquet Description:', 'Bounches is required', 'warning');
            return;
        }

        if (that.id_comida_bouquet <= 0) {
            that.aux.notification('Bouquet Description:', 'Food is required', 'warning');
            return;
        }

        debugger
        //Obtengo id detalle
        that.InsertBasicBouquetDescription();
        
        if (arrSleeve.length > 0)
            that.InsertSleeve({ value: arrSleeve.join(',') });
            
        var arrSticker = $.map(that.$tbSticker.bootstrapTable('getData'), function (value, key) {
            return value.id_sticker
        });

        if (arrSticker.length > 0)
            that.InsertSticker({ value: arrSticker.join(',') });
            
        that.InsertUPC();
        that.InsertObservation();
        that.LoadBouquets();
        that.aux.notification('', 'All saved', 'success');
        this.$tbBouquets.find('[id*=spLoadDetail]:eq(' + that.indexRowBouquet + ')').trigger('click');
    }

    this.InsertBasicBouquetDescription = function () {
        var dataBouquetRecipe = that.$tbBouquetRecipe.bootstrapTable('getData');
        var totalStems = 0;
        var arr = $.map(dataBouquetRecipe, function (value, key) {
            if (that.aux.nullOrEmpty(value.id_variedad_flor_cultivo) && that.aux.nullOrEmpty(value.id_grado_flor_cultivo) && that.aux.nullOrEmpty(value.cantidad_tallos))
                return value.id_variedad_flor_cultivo + ',' + value.id_grado_flor_cultivo + ',' + value.cantidad_tallos
        });
            
        var data = AjaxQuery2('../../../Old_App_Code/Natuflora/WebService/Bouquets/WSBouquets.asmx', 'InsertBouquetRecipe', 'POST',
        '{ "nombre_formula" : "' + that.$txtName.val() + '", "id_version_bouquet" : "' + that.dataDetailPO.id_version_bouquet +
        '", "especificacion" : "' + that.$txtaSpecs.val().replace('"', '') + '", "construccion":"' + that.$txtaConstruction.val() +
        '", "cadena_formula":"' + arr.join('$') + '", "opcion_menu": "0", "unidades":"' + that.$txtBunches.val() +
        '", "precio":' + that.$txtMiamiPrice.val() + ', "id_comida":"' + that.id_comida_bouquet +
        '", "id_detalle_version_bouquet":' + that.dataDetailBouquet.id_detalle_version_bouquet +
        ', "id_formato_upc": "' + that.id_formato_upc + '" }');

        that.dataDetailBouquet.id_detalle_version_bouquet = data[0].id_detalle_version_bouquet;
        that.CountStems();
    }

    this.InsertObservation = function () {
        var recipes = $.map(that.$tbBouquetRecipe.bootstrapTable('getData'), function (value, key) {
            if (that.aux.nullOrEmpty(value.id_variedad_flor_cultivo) && that.aux.nullOrEmpty(value.id_grado_flor_cultivo) && that.aux.nullOrEmpty(value.cantidad_tallos))
                return {
                    id_variedad_flor_cultivo: value.id_variedad_flor_cultivo,
                    id_grado_flor_cultivo: value.id_grado_flor_cultivo,
                    cantidad_tallos: value.cantidad_tallos,
                    observacion: value.observacion,
                    id_variedad_flor_cultivo_sustitucion: value.id_variedad_flor_cultivo_sustitucion,
                    id_grado_flor_cultivo_sustitucion: value.id_grado_flor_cultivo_sustitucion
                }
        });

        AjaxQuery2('../../../Old_App_Code/Natuflora/WebService/Bouquets/WSBouquets.asmx', 'InsertObservation', 'POST', '{"liRecipes": ' + JSON.stringify(recipes) + ', "id_formula_bouquet":"' + that.id_formula_bouquet + '", "id_detalle_version_bouquet":' + that.dataDetailBouquet.id_detalle_version_bouquet + '}');
    }

    this.OpenModalSearch = function (e, value, row, index) {
        that.IndiceUpdate = index;
        that.$mdSearchBouquet.modal('show');
    }

    this.LoadSearchBouquet = function () {
        var arrSearchBouquet = $.map(that.$selParametros.find('option:selected'), function (element, index) {
            return element.value
        });
        that.dataSearchBouquet = AjaxQuery2('../../../Old_App_Code/Natuflora/WebService/Bouquets/WSBouquets.asmx', 'ReadSearchBouquet', 'POST', '{ "texto" : "' + that.$txtTextSearch.val() + '", "columnas":"' + arrSearchBouquet.join() + '" }');
        that.$tbSearchBouquet.bootstrapTable('load', that.dataSearchBouquet);
    }

    this.CopyRecipe = function (e, value, row, index) {
        var dataExist = that.$tbBouquetRecipe.bootstrapTable('getData');
        var empty = dataExist.pop();
                
        var dataCopy = $.each(row, function (key, object) {
            if (row[key] == null)
                row[key] = '';
        });

        dataExist.splice(that.IndiceUpdate, 1, dataCopy)
        dataExist.push(empty);
        that.CountStems();
        that.$tbBouquetRecipe.bootstrapTable('load', dataExist);
        that.$tbSearchBouquet.bootstrapTable('load', []);
        that.$mdSearchBouquet.modal('hide');
    }

    this.CountStems = function () {
        var dataBouquetRecipe = that.$tbBouquetRecipe.bootstrapTable('getData');
        var totalStems = 0;

        $.each(dataBouquetRecipe, function (id, item) {
            if (isNaN(parseInt(item.cantidad_tallos)) == false)
                totalStems += parseInt(item.cantidad_tallos);
        });
        $('.badge').text(totalStems);
    }

    //#region Auxiliares //
    this.ClearDetailBouquet = function () {
        that.$txtName.val('');
        that.$txtaSpecs.val('');
        that.$txtaConstruction.val('');
        that.$txtBunches.val('');
        that.$txtMiamiPrice.val('');
        that.$txtFood.val('');
        that.$txtUPC.val('');
        that.$txtDescripcionUPC.val('');
        that.$txtFechaUPC.val('');
        that.$txtFormatoUPC.val('');
        that.$txtPrecioUPC.val('');
        that.$txtSleeve.val('');
        that.$txtSticker.val('');
        $('.badge').text('0');
        that.LoadEmptyDataBouquetRecipe();
        that.$tbSleeve.bootstrapTable('load', []);
        that.$tbSticker.bootstrapTable('load', []);
            
        $(that.dataDetailBouquet).cleanObject();
        that.dataDetailBouquet.id_detalle_version_bouquet = 0;
        that.id_comida_bouquet = 0;
    }

    this.DisabledDOM = function () {
        that.$rbFavorites.prop('disabled', that.dataDetailPO.id_status);
        that.$rbNewRecipe.prop('disabled', that.dataDetailPO.id_status);
        that.$btnSearch.prop('disabled', that.dataDetailPO.id_status);
        that.$btnClear.prop('disabled', that.dataDetailPO.id_status);
        that.$btnSaveAll.prop('disabled', that.dataDetailPO.id_status);
        that.$btnAdd.prop('disabled', that.dataDetailPO.id_status);
        that.$txtName.prop('disabled', that.dataDetailPO.id_status);
        that.$txtaSpecs.prop('disabled', that.dataDetailPO.id_status);
        that.$txtaConstruction.prop('disabled', that.dataDetailPO.id_status);
        that.$txtBunches.prop('disabled', that.dataDetailPO.id_status);
        that.$txtMiamiPrice.prop('disabled', that.dataDetailPO.id_status);
        that.$txtFood.prop('disabled', that.dataDetailPO.id_status);
        that.$txtDescripcionUPC.prop('disabled', that.dataDetailPO.id_status);
        that.$txtUPC.prop('disabled', that.dataDetailPO.id_status);
        that.$txtPrecioUPC.prop('disabled', that.dataDetailPO.id_status);
        that.$txtFechaUPC.prop('disabled', that.dataDetailPO.id_status);
        that.$txtFormatoUPC.prop('disabled', that.dataDetailPO.id_status);
        that.$txtSleeve.prop('disabled', that.dataDetailPO.id_status);
        that.$txtSticker.prop('disabled', that.dataDetailPO.id_status);
        that.$tbBouquets.prop('disabled', that.dataDetailPO.id_status);

        that.$tbBouquetRecipe.visible(!that.dataDetailPO.id_status);
        that.$tbDetFormulaOP3.visible(that.dataDetailPO.id_status);

        if (that.dataDetailPO.id_status){
            that.$tbBouquets.find('[id*=spDeleteRecipe]').off('click');
            that.$tbSleeve.find('[id*=spRemoveSleeve]').off('click');
            that.$tbSticker.find('[id*=spRemoveSticker]').off('click');
            that.$pnlUPC.sortable('disable');
        }
    }

    this.DisableUPC = function (upcformat) {
        that.$txtDescripcionUPC.prop('disabled', upcformat == 'NO UPC' ? true : false);
        that.$txtUPC.prop('disabled', upcformat == 'NO UPC' ? true : false);
        that.$txtPrecioUPC.prop('disabled', upcformat == 'NO UPC' ? true : false);
        that.$txtFechaUPC.prop('disabled', upcformat == 'NO UPC' ? true : false);
        that.$pnlUPC.sortable(upcformat == 'NO UPC' ? 'disable' : 'enable');
    }

    this.CalculateCheckDigit = function () {
        var val = that.$txtUPC.val();
        if (val.length == 11) {
            var arreglo = val.split("");
            var checkDigit = 0;
            for (i = 0; i < 11; i = i + 2) {
                checkDigit = checkDigit + parseInt(arreglo[i]);
            }
            checkDigit = checkDigit * 3;
            for (i = 1; i < 11; i = i + 2) {
                checkDigit = checkDigit + parseInt(arreglo[i]);
            }
            checkDigit = 10 - (checkDigit % 10);
            if (checkDigit == 10) { checkDigit = 0; }
                
            that.$txtUPC.popover('hide');
            $('#spUPCMessage').text(checkDigit);
        } else if (val.length < 11 && val.length > 0) {
            that.$txtUPC.attr('data-content', "* UPC field isn't complete");
            that.$txtUPC.popover('show');
            $('#spUPCMessage').text('');
        } else if(val.length === 0){
            $('#spUPCMessage').text('');
        }
    }

    this.SetValueBouncheRecipe = function (e, value, row, index) {
        row.cantidad_tallos = this.value;
    }        

    this.LoadEmptyDataBouquetRecipe = function () {
        var data = AjaxQuery2('../../../Old_App_Code/Natuflora/WebService/Bouquets/WSBouquets.asmx', 'ReadBouquetRecipe', 'POST', '{ "id_detalle_version_bouquet" : 0, "getModel" : true, "emptyRow" : false }');
        data = $.each(data, function (id, item) {
            data[id] = ''
        });
            
        var dataDetailBouquet = [];
        dataDetailBouquet.push(data);
        that.$tbBouquetRecipe.bootstrapTable('load', dataDetailBouquet);
    }
    //#endregion
}

$(document).on('ready', function () {
    var receta = new DefinirReceta();
    receta.Init();
})

function AjaxQuery2(destino, webMethod, metodo, data) {
    var objJson;
    $.ajax({
        type: metodo,
        url: destino + "/" + webMethod,
        contentType: "application/json; charset=utf-8",
        dataType: 'json',
        async: false,
        data: data,
        success: function (data) {
            objJson = JSON.parse(data.d);
        },
        failure: function () { alert("Fail"); objJson = null; }
    });
    return objJson;
}

