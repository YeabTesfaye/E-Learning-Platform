import { Metadata } from "next";
import Link from "next/link";
import { Button } from "@/components/ui/button";
import {
  Card,
  CardContent,
  CardDescription,
  CardFooter,
  CardHeader,
  CardTitle,
} from "@/components/ui/card";
import { Badge } from "@/components/ui/badge";
import { Input } from "@/components/ui/input";
import {
  Select,
  SelectContent,
  SelectItem,
  SelectTrigger,
  SelectValue,
} from "@/components/ui/select";

export const metadata: Metadata = {
  title: "Courses | EduLearn",
  description: "Browse our available courses",
};

const courses = [
  {
    id: 1,
    title: "Web Development Fundamentals",
    description:
      "Learn the basics of web development with HTML, CSS, and JavaScript",
    instructor: "John Doe",
    duration: "8 weeks",
    level: "Beginner",
    price: "$49.99",
    enrolled: 1234,
    rating: 4.5,
    image: "/courses/web-dev.jpg",
    category: "Web Development",
  },
  {
    id: 2,
    title: "Advanced React & Next.js",
    description: "Master modern React development with Next.js and TypeScript",
    instructor: "Jane Smith",
    duration: "10 weeks",
    level: "Advanced",
    price: "$79.99",
    enrolled: 856,
    rating: 4.8,
    image: "/courses/react.jpg",
    category: "JavaScript",
  },
  {
    id: 3,
    title: "Python for Data Science",
    description: "Learn Python programming for data analysis and visualization",
    instructor: "Mike Johnson",
    duration: "12 weeks",
    level: "Intermediate",
    price: "$69.99",
    enrolled: 2156,
    rating: 4.7,
    image: "/courses/python.jpg",
    category: "Data Science",
  },
  // Add more courses as needed
];

export default function CoursesPage() {
  return (
    <div className="flex-1 space-y-4 p-8 pt-6">
      <div className="flex items-center justify-between">
        <h2 className="text-3xl font-bold tracking-tight">Courses</h2>
      </div>

      <div className="flex items-center gap-4">
        <div className="flex-1">
          <Input placeholder="Search courses..." className="max-w-sm" />
        </div>
        <Select defaultValue="all">
          <SelectTrigger className="w-[180px]">
            <SelectValue placeholder="Category" />
          </SelectTrigger>
          <SelectContent>
            <SelectItem value="all">All Categories</SelectItem>
            <SelectItem value="web">Web Development</SelectItem>
            <SelectItem value="js">JavaScript</SelectItem>
            <SelectItem value="python">Python</SelectItem>
            <SelectItem value="data">Data Science</SelectItem>
          </SelectContent>
        </Select>
        <Select defaultValue="all">
          <SelectTrigger className="w-[180px]">
            <SelectValue placeholder="Level" />
          </SelectTrigger>
          <SelectContent>
            <SelectItem value="all">All Levels</SelectItem>
            <SelectItem value="beginner">Beginner</SelectItem>
            <SelectItem value="intermediate">Intermediate</SelectItem>
            <SelectItem value="advanced">Advanced</SelectItem>
          </SelectContent>
        </Select>
      </div>

      <div className="grid gap-6 md:grid-cols-2 lg:grid-cols-3">
        {courses.map((course) => (
          <Card key={course.id} className="flex flex-col">
            <Link
              href={`/courses/${course.id}`}
              className="flex flex-col flex-1"
            >
              <div className="aspect-video relative">
                <div className="absolute inset-0 bg-gradient-to-br from-blue-500 to-purple-600 rounded-t-lg" />
              </div>
              <CardHeader>
                <div className="flex items-center justify-between">
                  <Badge>{course.category}</Badge>
                  <Badge variant="outline">{course.level}</Badge>
                </div>
                <CardTitle className="line-clamp-2 mt-2">
                  {course.title}
                </CardTitle>
                <CardDescription className="line-clamp-2">
                  {course.description}
                </CardDescription>
              </CardHeader>
              <CardContent className="flex-1">
                <div className="flex items-center justify-between text-sm text-muted-foreground">
                  <div>Duration: {course.duration}</div>
                  <div>{course.enrolled.toLocaleString()} enrolled</div>
                </div>
                <div className="mt-2 flex items-center gap-2">
                  <div className="flex items-center">
                    {[...Array(5)].map((_, i) => (
                      <svg
                        key={i}
                        className={`h-4 w-4 ${
                          i < Math.floor(course.rating)
                            ? "text-yellow-400"
                            : "text-gray-300"
                        }`}
                        fill="currentColor"
                        viewBox="0 0 20 20"
                      >
                        <path d="M9.049 2.927c.3-.921 1.603-.921 1.902 0l1.07 3.292a1 1 0 00.95.69h3.462c.969 0 1.371 1.24.588 1.81l-2.8 2.034a1 1 0 00-.364 1.118l1.07 3.292c.3.921-.755 1.688-1.54 1.118l-2.8-2.034a1 1 0 00-1.175 0l-2.8 2.034c-.784.57-1.838-.197-1.539-1.118l1.07-3.292a1 1 0 00-.364-1.118L2.98 8.72c-.783-.57-.38-1.81.588-1.81h3.461a1 1 0 00.951-.69l1.07-3.292z" />
                      </svg>
                    ))}
                  </div>
                  <span className="text-sm text-muted-foreground">
                    ({course.rating})
                  </span>
                </div>
              </CardContent>
            </Link>
            <CardFooter className="flex items-center justify-between">
              <div className="text-lg font-bold">{course.price}</div>
              <Button asChild>
                <Link href={`/courses/${course.id}`}>Enroll Now</Link>
              </Button>
            </CardFooter>
          </Card>
        ))}
      </div>
    </div>
  );
}
