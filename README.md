# CKIPClient-CSharp
CKIP Client for C#

CKIP (Chinese Knowledge and Information Processing) 是中研院資科所詞庫小組所開發的斷詞系統，並提供了一個 Web Service 供研究者使用。CKIP Client 就是透過 TCP Socket 與此 Web Service 的溝通程式，目前網路上已經有 Java 和 PHP 的版本。 

本程式提供了 C# 環境下的連接方法，讓 C# developer 免除了程式碼轉換的困擾，並針對逗點和句點作了簡單的斷句處理。 


# 詞類標記
從 CKIP 的網站上可以找到詞類標記類表，裡面記載了線上斷詞服務會使用到的精簡詞類列表，詞類所代表的意義請參閱中研院平衡語料庫詞類標記集。
使用 CKIP 的 Web Service 所得到的斷詞結果除了精簡詞類列表中的詞性外，還包含了特殊符號，其代號為：

PARENTHESISCATEGORY：「 、」、（、）
ETCCATEGORY：…
COMMACATEGORY：，
COLONCATEGORY：：
QUESTIONCATEGORY：？
SEMICOLONCATEGORY：；
PAUSECATEGORY：、
PERIODCATEGORY：。、.
EXCLANATIONCATEGORY：！
所以如果只是要句子解析成「 詞」+「 詞性」，只需要基本的字串解析就夠了。方法如下所示：
string[] seperatorTerm = { " " }; 
string[] seperatorWA = { "(", ")" }; 
string[] terms = s.Split(seperatorTerm, StringSplitOptions.RemoveEmptyEntries); 

for (int i = 0; i < terms.Length; i++) 
{ 
    string[] termAndWA = terms[i].Split(seperatorWA, StringSplitOptions.None); 
    if (termAndWA[0] != "") 
    { 
        listBox1.Items.Add(termAndWA[0] + "\t詞性：" + termAndWA[1]); 
    } 
} 

這樣就可以把詞和詞性給解析出來囉，如果還需要繼續處理的話，可以再自行新增類別來儲存每個詞的資訊！