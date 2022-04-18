using System;


using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using Microsoft.Office.Core;
using Excel = Microsoft.Office.Interop.Excel;



namespace Login
{
    class Exportar
    {

        //Exporta Datagridview a Archivo de Excel
        public static void Exportar_Articulos(DataGridView grd)
        {
            try
            {
            
            SaveFileDialog fichero = new SaveFileDialog();
            fichero.Filter = "Excel (*.xls)|*.xls";
            fichero.FileName = "Archivo Exportado  " + DateTime.Today.ToString("dd-MM-yyyy");
                if (fichero.ShowDialog() == DialogResult.OK)
            {
                Microsoft.Office.Interop.Excel.Application aplicacion;
                Microsoft.Office.Interop.Excel.Workbook libros_trabajo;
                Microsoft.Office.Interop.Excel.Worksheet hoja_trabajo;

                aplicacion = new Microsoft.Office.Interop.Excel.Application();
                libros_trabajo = aplicacion.Workbooks.Add();
                hoja_trabajo =
                    (Microsoft.Office.Interop.Excel.Worksheet)libros_trabajo.Worksheets.get_Item(1);


                    hoja_trabajo.Rows.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;


                    Range rango = hoja_trabajo.Cells.Range[hoja_trabajo.Cells[1, 1], hoja_trabajo.Cells[1, grd.Columns.Count]];
                    rango.Font.Bold = true;
                    rango.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Silver);
                    rango.Borders.Weight = Excel.XlBorderWeight.xlThin;
                    rango.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                    rango.Borders.ColorIndex = Excel.XlColorIndex.xlColorIndexAutomatic;


                    for (int i = 2; i < grd.Columns.Count; i++)
                    {
                        hoja_trabajo.Cells[1, i - 1] = grd.Columns[i].HeaderCell.Value.ToString().ToUpper();

                    }



                    for (int i = 0; i < grd.Columns.Count; i++)
                    {
                        hoja_trabajo.Cells[1, i + 1] = grd.Columns[i].HeaderCell.Value.ToString().ToUpper();
                    }





                    for (int i = 0; i < grd.Rows.Count ; i++) //-1
                {
                    for (int j = 0; j < grd.Columns.Count; j++)
                    {
                        if ((grd.Rows[i].Cells[j].Value == null)==false)

                        {
                                
                                if (j ==2)
                                {


                                    hoja_trabajo.Cells[i + 2 , j + 1] = " " + grd.Rows[i].Cells[j].Value.ToString() + " ";
                                }
                                else { hoja_trabajo.Cells[i + 2, j + 1] = grd.Rows[i].Cells[j].Value.ToString(); }

                            }
                    }
                }
                    hoja_trabajo.Cells[grd.Rows.Count+3, 1] = "Exportado: "+DateTime.Today.ToString("dd/MM/yyyy");



                    libros_trabajo.SaveAs(fichero.FileName,
                    Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal);
                libros_trabajo.Close(true);
                aplicacion.Quit();
                MessageBox.Show("Archivo exportado correctamente");

                }
            }
            catch (Exception ex)
            {
              MessageBox.Show("Error al exportar la informacion debido a: "+ex.ToString());
            }
           
         }



        public static void Exportar2(DataGridView grd)
        {
            try
            {

                SaveFileDialog fichero = new SaveFileDialog();
                fichero.Filter = "Excel (*.xls)|*.xls";
                fichero.FileName = "Proyeccion  " + DateTime.Today.ToString("dd-MM-yyyy");
                if (fichero.ShowDialog() == DialogResult.OK)
                {
                    Microsoft.Office.Interop.Excel.Application aplicacion;
                    Microsoft.Office.Interop.Excel.Workbook libros_trabajo;
                    Microsoft.Office.Interop.Excel.Worksheet hoja_trabajo;

                    aplicacion = new Microsoft.Office.Interop.Excel.Application();
                    libros_trabajo = aplicacion.Workbooks.Add();
                    hoja_trabajo =
                        (Microsoft.Office.Interop.Excel.Worksheet)libros_trabajo.Worksheets.get_Item(1);


                    hoja_trabajo.Rows.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    

                    Range rango = hoja_trabajo.Cells.Range[hoja_trabajo.Cells[1, 1], hoja_trabajo.Cells[1, 15]];
                    rango.Font.Bold = true;
                    rango.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Silver);
                    rango.Borders.Weight = Excel.XlBorderWeight.xlThin;
                    rango.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                    rango.Borders.ColorIndex = Excel.XlColorIndex.xlColorIndexAutomatic;
                    

                    for (int i = 2; i < grd.Columns.Count; i++)
                    {
                        hoja_trabajo.Cells[1, i - 1] = grd.Columns[i].HeaderCell.Value.ToString().ToUpper();
                      
                    }



                    int acumulados = 0;

                    for (int i = 0; i < grd.Rows.Count; i++) //-1
                    {
                        

                        if ((bool)grd.Rows[i].Cells[0].Value == true)
                        {
                            for (int j = 2; j < grd.Columns.Count; j++)
                            {
                            
                                if ((grd.Rows[i].Cells[j].Value == null) == false)
                                {
                                    if (j >= 3 && j <= 4) {
                                        
       
                                        hoja_trabajo.Cells[i + 2 - acumulados, j -1] = " " + grd.Rows[i].Cells[j].Value.ToString() + " ";
                                        
                                    }
                                    else { hoja_trabajo.Cells[i + 2 - acumulados, j -1] = grd.Rows[i].Cells[j].Value.ToString(); }
                                    
                                    
                                }
                            }
                            
                        }
                        else { acumulados += 1; }
                    }
                    hoja_trabajo.Cells[grd.Rows.Count + 3-acumulados, 1] = "Exportado: " + DateTime.Today.ToString("dd/MM/yyyy");
                    Range rango2 = hoja_trabajo.Cells.Range[hoja_trabajo.Cells[grd.Rows.Count + 3 - acumulados, 1], hoja_trabajo.Cells[grd.Rows.Count + 3 - acumulados, 2]];
                    rango2.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;

                    libros_trabajo.SaveAs(fichero.FileName,
                    Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal);
                    libros_trabajo.Close(true);
                    aplicacion.Quit();
                    MessageBox.Show("Archivo exportado correctamente");

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al exportar la informacion debido a: " + ex.ToString());
            }

        }
    }
    }


