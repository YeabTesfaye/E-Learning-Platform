"use client";

import { Progress } from "@/components/ui/progress";

const stats = [
  {
    id: 1,
    title: "Course Completion Rate",
    value: 85,
    description: "Average across all courses",
  },
  {
    id: 2,
    title: "Quiz Performance",
    value: 92,
    description: "Average score in quizzes",
  },
  {
    id: 3,
    title: "Weekly Goal Progress",
    value: 60,
    description: "5 of 8 hours completed",
  },
];

export function DashboardStats() {
  return (
    <div className="space-y-8">
      {stats.map((stat) => (
        <div key={stat.id} className="space-y-2">
          <div className="flex items-center justify-between">
            <p className="text-sm font-medium leading-none">{stat.title}</p>
            <p className="text-sm text-muted-foreground">{stat.value}%</p>
          </div>
          <Progress value={stat.value} className="h-2" />
          <p className="text-xs text-muted-foreground">{stat.description}</p>
        </div>
      ))}
    </div>
  );
}
