"use client";

import { Avatar, AvatarFallback, AvatarImage } from "@/components/ui/avatar";

const activities = [
  {
    id: 1,
    title: "Completed Introduction to React",
    timestamp: "2 hours ago",
    type: "completion",
    course: "Web Development Fundamentals",
    icon: "R",
  },
  {
    id: 2,
    title: "Started new lesson: Advanced CSS",
    timestamp: "4 hours ago",
    type: "start",
    course: "CSS Mastery",
    icon: "C",
  },
  {
    id: 3,
    title: "Earned certificate in Python Basics",
    timestamp: "1 day ago",
    type: "achievement",
    course: "Python Programming",
    icon: "P",
  },
  {
    id: 4,
    title: "Submitted project: Portfolio Website",
    timestamp: "2 days ago",
    type: "submission",
    course: "Web Development Fundamentals",
    icon: "W",
  },
];

export function RecentActivities() {
  return (
    <div className="space-y-8">
      {activities.map((activity) => (
        <div key={activity.id} className="flex items-center">
          <Avatar className="h-9 w-9">
            <AvatarImage
              src={`/course-icons/${activity.icon.toLowerCase()}.png`}
              alt={activity.course}
            />
            <AvatarFallback>{activity.icon}</AvatarFallback>
          </Avatar>
          <div className="ml-4 space-y-1">
            <p className="text-sm font-medium leading-none">{activity.title}</p>
            <p className="text-sm text-muted-foreground">
              {activity.course} • {activity.timestamp}
            </p>
          </div>
        </div>
      ))}
    </div>
  );
}
