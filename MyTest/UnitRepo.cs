using System;
using Xunit;

namespace MyTest
{
    public class UnitRepo
    {
        private IUnitOfWork _UOW;
        [Fact]
        public void UnitRepo(IUnitOfWork uow)
        {
            _UOW = uow;
        }
        private var repositoryk = _UOW.GetRepositoryAsync<KnowledgeElement>();
        private var repositorys = _UOW.GetRepositoryAsync<SkillLevel>();
        private var repositoryd = _UOW.GetRepositoryAsync<Disposition>();



        [Theory]
        [InlineData(1,"KnowledgeElement")]
        [InlineData(2,"KnowledgeElement")]
        [InlineData(3,"KnowledgeElement")]
        [InlineData(1,"SkillLevel")]
        [InlineData(2,"SkillLevel")]
        [InlineData(3,"SkillLevel")]
        [InlineData(1,"Disposition")]
        [InlineData(2,"Disposition")]
        [InlineData(3,"Dispsosition")]
        public void DoesDeleteWork(int x, string type)
        {
            switch(type){
                case "KnowledgeElement":
               
                break;
                case "SkillLevel":
                
                break;
                case "Disposition":
                
                break;
            }
        }
    }
}
