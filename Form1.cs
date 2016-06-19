using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json; // مكتبة التعامل مع json 
using Newtonsoft.Json.Linq;

namespace IR_assignment
{

    public partial class Form1 : Form
    {
        // ----------------------------------------------------------------------------------
        // عند بدء عمل الفورم الحالي
        public Form1()
        {
            InitializeComponent();
            InitializeOpenFileDialog(); // دالة فلترة اختيار الوثائق                                    

        }
        // ----------------------------------------------------------------------------------
        // دالة إضافة ملف إلى الأرشيف
        private void AddToIndex(string file)
        {
            // قراءة محتوى الملف
            string FileContent = File.ReadAllText(file);

            /* tokenization التقطيع  */
            string[] words = FileContent.Split(new char[] { ' ', '.', '?' }, StringSplitOptions.RemoveEmptyEntries); // تقسيم النص إلى كلمات 
            foreach (string word in words) // حلقة تكرارية على كلمات الملف
            {
                // حذف كل شيء ماعدا الأحرف الأبجدية
                string PlainWord = Regex.Replace(word, @"[^\p{L}]+", "");

                // استبعاد الكلمات التي أصبحت فارغة أو إن كانت حرف واحد فقط
                if (PlainWord == "" || PlainWord.Length < 2) continue;
                // MessageBox.Show(PlainWord.ToLower());
            }
        }
        // -------------------------------------------------------------------------
        public void AddToDocuments()
        {
            // أول ملف من الملفات التي تم اختيارها
            Document d = new Document { DocId = 1, DocPath = openFileDialog1.FileNames[0] };

            // JSON object تعريف
            JObject jo = JObject.FromObject(d);
            
           int i = 1;
            // بقية الملفات التي تم اختيارها
            foreach (String f in openFileDialog1.FileNames)
            {
                // if (i == 1) continue; // تخطي أول عنصر كونه تم تعريفه قبل الحلقة
              
                jo.Add(new Document { DocId = i, DocPath = f} ); // إضافة الوثيقة إلى كائن جي سون
                i++;
            }
            // إضافة الوثيقة إلى أرشيف الوثقائق

            MessageBox.Show(jo.ToString());
            /*  convert to json: فيما يلي التحويل إلى جي سون */
            string json = JsonConvert.SerializeObject(jo.ToString());
            string JsonFilePath = Application.StartupPath + "\\documents.json";
            File.WriteAllText(JsonFilePath, json); // حفظ أرشيف الوثا ئق
            MessageBox.Show("تم إضافة الوثيقة إلى الفهرس");
        }
        // -------------------------------------------------------------------------
        // دالة فلترة اختيار الوثائق
        private void InitializeOpenFileDialog()
        {
            // فلتر اختيار ملفات نصية وصفحات ويب فقط
            this.openFileDialog1.Filter =
                "Web Pages (*.HTML;*.TXT;*.XML)|*.HTML;*.TXT;*.XML|" + "All files (*.*)|*.*"; // الامتدادات المسموحة

            // السماح للمستخدم بتحديد عدة ملفات معاً
            this.openFileDialog1.Multiselect = true;
            this.openFileDialog1.Title = "اختيار الوثائق";
        }
        // ----------------------------------------------------------------------------------
        // الضغط على زر اختيار وثائق وإضافتها للفهرس
        private void SelectDocsBtn_Click(object sender, EventArgs e)
        {
            DialogResult dr = this.openFileDialog1.ShowDialog(); // إظهار نافذة الاستعراض
            if (dr == DialogResult.OK)
            {
                AddToDocuments(); // إضافة إلى فهرس الوثائق documents.json
                // قراء الملفات
                foreach (String file in openFileDialog1.FileNames)
                {
                    AddToIndex(file); // إضافة محتوى الوثيقة إلى الفهرس العكسي
                } // end foreach;
            } // end if;
        } // end SelectDocsBtn_Click;
        // ----------------------------------------------------------------------------------
    } // end class Form1;
    // ----------------------------------------------------------------------------------
    class Document // صف خاص بالوثائق
    {
        public int DocId { get; set; } // معرف الوثيقة
        public string DocPath { get; set; } // مسار الوثيقة
    }// end class Document
    // ----------------------------------------------------------------------------------
}
