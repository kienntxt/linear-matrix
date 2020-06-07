using CalcLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CalcTools
{
    public partial class MainFrm : Form
    {
        public MainFrm()
        {
            InitializeComponent();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            _data.Clear();
            dgvData.Rows.Clear();
            dgvData.Columns.Clear();
        }

        private void btnInput_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtValue.Text))
                {
                    MessageBox.Show("Invalid value (decimal)");
                    return;
                }

                string s = txtValue.Text;
                decimal d;
                if (!decimal.TryParse(s, out d))
                {
                    MessageBox.Show("Invalid value (decimal)");
                    return;
                }

                if (radArea.Checked)
                {
                    int ci = dgvData.Columns.Add($"R_{dgvData.Columns.Count + 1}", $"{d} (ha)");
                    dgvData.Columns[ci].SortMode = DataGridViewColumnSortMode.NotSortable;
                    dgvData.Columns[ci].HeaderCell.Tag = d;
                }
                if (radDistance.Checked)
                {
                    int ri = dgvData.Rows.Add();
                    dgvData.Rows[ri].HeaderCell.Value = $"{d} (m)";
                    dgvData.Rows[ri].HeaderCell.Tag = d;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvData.Rows.Count == 0 || dgvData.Columns.Count == 0)
                {
                    MessageBox.Show("No input data");
                    return;
                }
                decimal rx;
                if (!decimal.TryParse(txtArea.Text, out rx))
                {
                    MessageBox.Show("Invalid calculating area");
                    return;
                }
                decimal kx;
                if (!decimal.TryParse(txtDistance.Text, out kx))
                {
                    MessageBox.Show("Invalid calculating distance");
                    return;
                }

                _data = _collectData(true);
                var result = CalcLib.TinhToan.NoiSuyH(_data, rx, kx);
                txtLevel.Text = $"{result}";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        List<MucNuocLonNhatTaiViTriBai> _data = new List<MucNuocLonNhatTaiViTriBai>();

        private void btnLoad_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog dlg = new OpenFileDialog();
                dlg.Filter = "CSV file|*.csv;*.txt|All files|*.*";
                dlg.DefaultExt = ".csv";
                dlg.Multiselect = false;
                dlg.Title = "Open CSV formatted file";
                var result = dlg.ShowDialog();
                if (result != DialogResult.OK)
                    return;

                _data = _loadFile(dlg.FileName);
                dgvData.Rows.Clear();
                dgvData.Columns.Clear();

                var rs = _data.Select(x => x.R).Distinct().OrderBy(x => x).ToArray();
                var ks = _data.Select(x => x.K).Distinct().OrderByDescending(x => x).ToArray();

                foreach (var r in rs)
                {
                    int coli = dgvData.Columns.Add($"R_{dgvData.Columns.Count + 1}", $"{r} (ha)");
                    dgvData.Columns[coli].SortMode = DataGridViewColumnSortMode.NotSortable;
                    dgvData.Columns[coli].HeaderCell.Tag = r;
                }
                foreach (var k in ks)
                {
                    int rowi = dgvData.Rows.Add();
                    dgvData.Rows[rowi].HeaderCell.Value = $"{k} (m)";
                    dgvData.Rows[rowi].HeaderCell.Tag = k;
                }
                for (int r = 0; r < rs.Length; r++)
                {
                    var dr = _data.Where(x => x.R == rs[r]).OrderByDescending(x => x.K).ToArray();
                    for (int k = 0; k < dr.Length; k++)
                    {
                        dgvData.Rows[k].Cells[r].Value = dr[k].H;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog dlg = new SaveFileDialog();
                dlg.Filter = "CSV file|*.csv;*.txt|All files|*.*";
                dlg.DefaultExt = ".csv";
                dlg.Title = "Save as CSV formatted file";
                var result = dlg.ShowDialog();
                if (result != DialogResult.OK)
                    return;

                //treat non-value cells as 0
                _data = _collectData(false);
                _saveFile(dlg.FileName, _data);
                MessageBox.Show("Data is saved successfully!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        List<MucNuocLonNhatTaiViTriBai> _collectData(bool throwing = true)
        {
            var lst = new List<MucNuocLonNhatTaiViTriBai>();
            for (int i = 0; i < dgvData.Columns.Count; i++)
            {
                var r = (decimal)dgvData.Columns[i].HeaderCell.Tag;
                for (int j = 0; j < dgvData.Rows.Count; j++)
                {
                    var k = (decimal)dgvData.Rows[j].HeaderCell.Tag;
                    decimal h;
                    if (dgvData.Rows[j].Cells[i].Value == null)
                    {
                        if (throwing)
                            throw new Exception($"Invalid data: value of cell (row= {k}, column= {r}) is not decimal");
                        else
                            lst.Add(new MucNuocLonNhatTaiViTriBai { R = r, K = k, H = 0 });
                    }
                    else
                    {
                        if (decimal.TryParse(dgvData.Rows[j].Cells[i].Value.ToString(), out h))
                            lst.Add(new MucNuocLonNhatTaiViTriBai { R = r, K = k, H = h });
                        else
                        {
                            if (throwing)
                                throw new Exception($"Invalid data: value of cell (row= {k}, column= {r}) is not decimal");
                            else
                                lst.Add(new MucNuocLonNhatTaiViTriBai { R = r, K = k, H = 0 });
                        }
                    }
                }
            }
            return lst;
        }

        List<MucNuocLonNhatTaiViTriBai> _loadFile(string fpath)
        {
            StreamReader sr = null;
            try
            {
                sr = File.OpenText(fpath);

                //first row is K (distances)
                var kline = sr.ReadLine();
                if (!kline.StartsWith("K:", StringComparison.InvariantCultureIgnoreCase))
                    throw new Exception("Invalid file format:\r\nSecond row must be masked with K: (for distances)");

                //second row is R (areas)
                var rline = sr.ReadLine();
                if (!rline.StartsWith("R:", StringComparison.InvariantCultureIgnoreCase))
                    throw new Exception("Invalid file format:\r\nFirst row must be masked with R: (for areas)");

                var rlst = new List<decimal>();
                var rs = rline.Split(new string[] { ":", "," }, StringSplitOptions.RemoveEmptyEntries);
                if (rs.Length <= 1)
                    throw new Exception("Invalid file format:\r\nNo area is defined");

                for (int i = 1; i < rs.Length; i++)
                {
                    decimal d;
                    if (!decimal.TryParse(rs[i], out d))
                        throw new Exception($"Invalid file format:\r\nInvalid area number (decimal) at position [{i + 1}] in R line");

                    rlst.Add(d);
                }
                var klst = new List<decimal>();
                var ks = kline.Split(new string[] { ":", "," }, StringSplitOptions.RemoveEmptyEntries);
                if (ks.Length <= 1)
                    throw new Exception("Invalid file format:\r\nNo distance is defined");

                for (int i = 1; i < ks.Length; i++)
                {
                    decimal d;
                    if (!decimal.TryParse(ks[i], out d))
                        throw new Exception($"Invalid file format:\r\nInvalid distance number (decimal) at position [{i + 1}] in K line");

                    klst.Add(d);
                }

                var content = sr.ReadToEnd();
                var rows = content.Split(new string[] { "\r\n", "\n" }, StringSplitOptions.RemoveEmptyEntries);
                if (rows.Length != klst.Count)
                    throw new Exception($"Invalid file format:\r\nRows count [{rows.Length}] is not matched distances count [{klst.Count}]");

                List<MucNuocLonNhatTaiViTriBai> lst = new List<MucNuocLonNhatTaiViTriBai>();
                for (int i = 0; i < rows.Length; i++)
                {
                    var hs = rows[i].Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
                    if (hs.Length != rlst.Count)
                        throw new Exception($"Invalid file format:\r\nData row [{i + 1}] > Columns count [{hs.Length}] is not matched areas count [{rlst.Count}]");

                    for (int j = 0; j < hs.Length; j++)
                    {
                        decimal d;
                        if (!decimal.TryParse(hs[j], out d))
                            throw new Exception($"Invalid file format:\r\nData row [{i + 1}] > invalid decimal value at [{j + 1}]");

                        lst.Add(new MucNuocLonNhatTaiViTriBai { H = d, K = klst[i], R = rlst[j] });
                    }
                }
                return lst;
            }
            finally
            {
                if (sr != null)
                    sr.Close();
            }
        }

        void _saveFile(string fpath, List<MucNuocLonNhatTaiViTriBai> data)
        {
            TextWriter tw = null;
            try
            {
                if (File.Exists(fpath))
                    File.Delete(fpath);
                tw = File.AppendText(fpath);
                var rs = data.Select(x => x.R).Distinct().OrderBy(r => r).ToList();
                var ks = data.Select(x => x.K).Distinct().OrderByDescending(k => k).ToList();
                //write first line (K)
                var kline = "K: " + string.Join(", ", ks);
                if (kline.EndsWith(", "))
                    kline = kline.Remove(kline.Length - 2);
                tw.WriteLine(kline);
                //write second line (R)
                var rline = "R: " + string.Join(", ", rs);
                if (rline.EndsWith(", "))
                    rline = rline.Remove(rline.Length - 2);
                tw.WriteLine(rline);

                ks.ForEach((k) =>
                {
                    var hs = data.Where(x => x.K == k).OrderBy(x => x.R).Select(x => x.H).ToArray();
                    var hline = string.Join(", ", hs);
                    if (hline.EndsWith(", "))
                        hline = hline.Remove(hline.Length - 2);
                    tw.WriteLine(hline);
                });
            }
            finally
            {
                if (tw != null)
                    tw.Close();
            }
        }
    }
}
