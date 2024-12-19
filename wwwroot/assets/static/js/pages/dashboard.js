document.addEventListener("DOMContentLoaded", function () {
  // Tasks Overview - Bar Chart
  var optionsTaskOverview = {
      annotations: {
          position: "back",
      },
      dataLabels: {
          enabled: false,
      },
      chart: {
          type: "bar",
          height: 300,
      },
      fill: {
          opacity: 1,
      },
      series: [
          {
              name: "Tasks",
              data: [45, 12, 8, 5], // Completed, Pending, In Progress, Overdue
          },
      ],
      colors: ["#28a745", "#dc3545", "#007bff", "#6f42c1"], // Green, Red, Blue, Purple
      xaxis: {
          categories: ["Completed", "Pending", "In Progress", "Overdue"],
      },
  };

  // Task Type - Donut Chart
  let optionsTaskType = {
      series: [40, 30, 15, 15], // High, Medium, Low, Other
      labels: ["High Priority", "Medium Priority", "Low Priority", "Other"],
      colors: ["#dc3545", "#ffc107", "#28a745", "#6c757d"], // Red, Yellow, Green, Gray
      chart: {
          type: "donut",
          width: "100%",
          height: "350px",
      },
      legend: {
          position: "bottom",
      },
      plotOptions: {
          pie: {
              donut: {
                  size: "30%",
              },
          },
      },
  };

  // Task Completion - Area Chart (Trend Over Time)
  var optionsTaskTrend = {
      series: [
          {
              name: "Tasks Completed",
              data: [5, 10, 15, 20, 25, 30, 40, 45], // Sample data
          },
      ],
      chart: {
          height: 80,
          type: "area",
          toolbar: {
              show: false,
          },
      },
      colors: ["#28a745"],
      stroke: {
          width: 2,
      },
      grid: {
          show: false,
      },
      dataLabels: {
          enabled: false,
      },
      xaxis: {
          type: "datetime",
          categories: [
              "2024-06-01T00:00:00.000Z",
              "2024-06-02T00:00:00.000Z",
              "2024-06-03T00:00:00.000Z",
              "2024-06-04T00:00:00.000Z",
              "2024-06-05T00:00:00.000Z",
              "2024-06-06T00:00:00.000Z",
              "2024-06-07T00:00:00.000Z",
              "2024-06-08T00:00:00.000Z",
          ],
          axisBorder: {
              show: false,
          },
          axisTicks: {
              show: false,
          },
          labels: {
              show: true,
          },
      },
      yaxis: {
          labels: {
              show: false,
          },
      },
      tooltip: {
          x: {
              format: "dd/MM/yy",
          },
      },
  };

  // Render Charts
  var chartTaskOverview = new ApexCharts(
      document.querySelector("#chart-tasks-overview"),
      optionsTaskOverview
  );
  var chartTaskType = new ApexCharts(
      document.querySelector("#chart-task-type"),
      optionsTaskType
  );
  var chartTaskTrend = new ApexCharts(
      document.querySelector("#chart-profile-visit"),
      optionsTaskTrend
  );

  chartTaskOverview.render();
  chartTaskType.render();
  chartTaskTrend.render();
});
