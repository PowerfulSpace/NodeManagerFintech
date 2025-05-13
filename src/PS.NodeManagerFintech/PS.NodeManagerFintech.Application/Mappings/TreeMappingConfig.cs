using Mapster;
using PS.NodeManagerFintech.Application.DTOs;
using PS.NodeManagerFintech.Domain.Entities;

namespace PS.NodeManagerFintech.Application.Mappings
{
    public class TreeMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<TreeNode, TreeNodeDto>();
            config.NewConfig<Tree, TreeDto>();
        }
    }
}
