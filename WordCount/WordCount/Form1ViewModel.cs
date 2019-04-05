using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordCount
{
    public class Form1ViewModel
    {
        public BindingList<Word> Words { get; set; }
        public Form1ViewModel()
        {
            Words = new BindingList<Word>();

        }
        private Word GetByString(string text)
        {
            foreach(Word w in Words)
            {
                if (w.SingleWord.Equals(text))
                {
                    return w;
                }
            }
            return null;
        }
        public void CountWords(string text)
        {
            string[] lines = text.Split('\n');
            for(int i = 0; i < lines.Length; i++)
            {
                string[] line = lines[i].Split(' ');
                for(int j = 0; j < line.Length; j++)
                {
                    Word w = new Word();
                    w.SingleWord = line[j];
                    if (GetByString(line[j]) != null)
                    {
                        GetByString(line[j]).count += 1;
                    }
                    else
                    {
                        w.count = 1;
                        Words.Add(w);
                    }
                }
            }
            Sort();
        }
        public void Sort()
        {
            for(int i = 0; i < Words.Count; i++)
            {
                int currentIndex = i;
                Word currData = Words[i];
                while(currentIndex > 0 && Words[currentIndex-1].count < currData.count)
                {
                    Words[currentIndex] = Words[currentIndex - 1];
                    currentIndex--;
                }
                Words[currentIndex] = currData;
            }
        }
    }

}
