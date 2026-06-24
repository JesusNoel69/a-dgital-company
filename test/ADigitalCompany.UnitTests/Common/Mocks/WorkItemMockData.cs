using ADigitalCompany.Application.Features.WorkItems.Commands.ChangePriority;
using ADigitalCompany.Domain;
using ADigitalCompany.Domain.Enums;

namespace ADigitalCompany.UnitTests.Common.Mocks
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