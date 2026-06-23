using a_digital_company.Application.Features.WorkItems.Commands.ChangePriority;
using a_digital_company.Domain;
using a_digital_company.Domain.Enums;

namespace a_digital_company.UnitTests.Common.Mocks
{
    public static class WorkItemMockData
    {
        public static WorkItem GetWorkItem(WorkItemPriority? priority)
        {
            return new WorkItem(
                "Task",
                "Description",
                "user1",
                priority?? WorkItemPriority.Medium);
        }

        public static List<WorkItem> GetWorkItems()
        {
            return
            [
                GetWorkItem(null),
                new WorkItem(
                    "Task 2",
                    "Description 2",
                    "user2",
                    WorkItemPriority.High)
            ];
        }
    }
}