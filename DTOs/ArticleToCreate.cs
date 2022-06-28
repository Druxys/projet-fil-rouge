namespace ProjetFilBleu_AppBureauxDEtudes.DTOs
{
    public class ArticleToCreate
    {
        public string codeArticle { get; set; }
        public string codeCategorie { get; set; }
        public string codeOperation { get; set; }
        public ArticleToCreateChildArticle[] articles { get; set; } = new ArticleToCreateChildArticle[2];

        public bool VerifyArticleToCreate()
        {
            if (this.articles == null || this.articles.Length <= 0 || this.articles.Length > 2)
                return false;

            if (string.IsNullOrWhiteSpace(this.codeArticle) || string.IsNullOrWhiteSpace(this.codeOperation))
                return false;

            return true;
        }
    }

    public class ArticleToCreateChildArticle
    {
        public string codeArticle { get; set; }
        public int quantite { get; set; }
    }
}
