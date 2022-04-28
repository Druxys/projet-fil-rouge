namespace ProjetFilBleu_AppBureauxDEtudes.DTOs
{
    public class ArticleToCreate
    {
        public int codeArticle { get; set; }
        public int? codeCategorie { get; set; }
        public int codeOperation { get; set; }
        public ArticleToCreateChildArticle[] articles { get; set; } = new ArticleToCreateChildArticle[2];

        public bool VerifyArticleToCreate()
        {
            if (this.articles == null || this.articles.Length <= 0 || this.articles.Length > 2)
                return false;

            if (codeArticle == 0 || codeOperation == 0)
                return false;

            if (codeCategorie == 0)
                codeCategorie = null;

            return true;
        }
    }

    public class ArticleToCreateChildArticle
    {
        public int codeArticle { get; set; }
        public int quantite { get; set; }
    }
}
