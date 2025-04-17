"use client";

import { CalendarDays } from "lucide-react";
import { Button } from "@/components/ui/button";

const upcomingLessons = [
  {
    id: 1,
    title: "JavaScript Fundamentals",
    course: "Web Development Basics",
    date: "Tomorrow",
    time: "10:00 AM",
    duration: "1h 30m",
  },
  {
    id: 2,
    title: "React Components",
    course: "React Masterclass",
    date: "Wed, Mar 20",
    time: "2:00 PM",
    duration: "2h",
  },
  {
    id: 3,
    title: "API Integration",
    course: "Backend Development",
    date: "Thu, Mar 21",
    time: "11:00 AM",
    duration: "1h",
  },
];

export function UpcomingLessons() {
  return (
    <div className="space-y-8">
      {upcomingLessons.map((lesson) => (
        <div key={lesson.id} className="flex items-start justify-between">
          <div className="space-y-1">
            <p className="text-sm font-medium leading-none">{lesson.title}</p>
            <p className="text-sm text-muted-foreground">{lesson.course}</p>
            <div className="flex items-center pt-2">
              <CalendarDays className="mr-2 h-4 w-4 opacity-70" />
              <span className="text-xs text-muted-foreground">
                {lesson.date} • {lesson.time} • {lesson.duration}
              </span>
            </div>
          </div>
          <Button
            variant="outline"
            className="ml-4"
            onClick={() =>
              window.open(`/courses/lesson/${lesson.id}`, "_blank")
            }
          >
            Join
          </Button>
        </div>
      ))}
    </div>
  );
}
