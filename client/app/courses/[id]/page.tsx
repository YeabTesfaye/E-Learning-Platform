import { Metadata } from "next";
import { notFound } from "next/navigation";
import { Button } from "@/components/ui/button";
import {
  Card,
  CardContent,
  CardDescription,
  CardHeader,
  CardTitle,
} from "@/components/ui/card";
import { Badge } from "@/components/ui/badge";
import { Tabs, TabsContent, TabsList, TabsTrigger } from "@/components/ui/tabs";
import { Avatar, AvatarFallback, AvatarImage } from "@/components/ui/avatar";

// This would typically come from your database
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
    syllabus: [
      {
        title: "Introduction to Web Development",
        lessons: [
          "What is Web Development?",
          "Setting Up Your Development Environment",
          "Understanding the Web",
        ],
      },
      {
        title: "HTML Fundamentals",
        lessons: [
          "HTML Structure",
          "Common HTML Elements",
          "Forms and Input Elements",
        ],
      },
      {
        title: "CSS Basics",
        lessons: [
          "CSS Syntax",
          "Selectors and Properties",
          "Box Model and Layout",
        ],
      },
      {
        title: "JavaScript Essentials",
        lessons: [
          "Variables and Data Types",
          "Control Flow",
          "Functions and Objects",
        ],
      },
    ],
    requirements: [
      "Basic computer skills",
      "A computer with internet access",
      "No prior programming experience required",
    ],
    whatYouWillLearn: [
      "Build responsive websites from scratch",
      "Understand core web development concepts",
      "Write clean and maintainable code",
      "Deploy websites to the internet",
    ],
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
    syllabus: [
      {
        title: "React Fundamentals",
        lessons: [
          "Modern React Development",
          "Hooks and State Management",
          "Component Patterns",
        ],
      },
      {
        title: "Next.js Essentials",
        lessons: [
          "Server-Side Rendering",
          "Static Site Generation",
          "API Routes and Data Fetching",
        ],
      },
      {
        title: "TypeScript Integration",
        lessons: [
          "TypeScript Basics",
          "Type-Safe Components",
          "Advanced Types in React",
        ],
      },
      {
        title: "Advanced Concepts",
        lessons: [
          "Performance Optimization",
          "Testing React Applications",
          "Deployment Strategies",
        ],
      },
    ],
    requirements: [
      "Solid understanding of JavaScript",
      "Basic knowledge of React",
      "Familiarity with npm/yarn",
      "Understanding of modern ES6+ features",
    ],
    whatYouWillLearn: [
      "Build full-stack applications with Next.js",
      "Write type-safe React applications",
      "Implement advanced React patterns",
      "Deploy and optimize React applications",
    ],
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
    syllabus: [
      {
        title: "Python Basics for Data Science",
        lessons: [
          "Python Programming Fundamentals",
          "Data Types and Structures",
          "Working with Files and APIs",
        ],
      },
      {
        title: "Data Analysis with Pandas",
        lessons: [
          "Introduction to Pandas",
          "Data Cleaning and Preprocessing",
          "Data Manipulation and Analysis",
        ],
      },
      {
        title: "Data Visualization",
        lessons: [
          "Matplotlib Fundamentals",
          "Interactive Visualizations with Plotly",
          "Creating Dashboards",
        ],
      },
      {
        title: "Machine Learning Basics",
        lessons: [
          "Introduction to NumPy",
          "Statistical Analysis",
          "Basic Machine Learning Models",
        ],
      },
    ],
    requirements: [
      "Basic programming knowledge",
      "Understanding of basic mathematics",
      "Computer with Python installed",
      "Enthusiasm for data analysis",
    ],
    whatYouWillLearn: [
      "Analyze data using Python and Pandas",
      "Create compelling data visualizations",
      "Apply statistical analysis techniques",
      "Build basic machine learning models",
    ],
  },
];

export async function generateMetadata({
  params,
}: {
  params: { id: string };
}): Promise<Metadata> {
  const course = courses.find((c) => c.id === parseInt(params.id));
  if (!course) return { title: "Course Not Found" };

  return {
    title: `${course.title} | EduLearn`,
    description: course.description,
  };
}

export default function CoursePage({ params }: { params: { id: string } }) {
  const course = courses.find((c) => c.id === parseInt(params.id));
  if (!course) notFound();

  return (
    <div className="flex-1 space-y-6 p-8 pt-6">
      <div className="flex flex-col gap-4 md:flex-row md:items-start md:justify-between">
        <div>
          <div className="flex items-center gap-2">
            <Badge>{course.category}</Badge>
            <Badge variant="outline">{course.level}</Badge>
          </div>
          <h1 className="mt-2 text-3xl font-bold tracking-tight">
            {course.title}
          </h1>
          <p className="mt-2 text-lg text-muted-foreground">
            {course.description}
          </p>
        </div>
        <Card className="w-full md:w-72">
          <CardHeader>
            <CardTitle className="text-2xl">{course.price}</CardTitle>
            <CardDescription>Lifetime access</CardDescription>
          </CardHeader>
          <CardContent className="space-y-4">
            <div className="space-y-2">
              <div className="flex justify-between text-sm">
                <span>Duration:</span>
                <span className="font-medium">{course.duration}</span>
              </div>
              <div className="flex justify-between text-sm">
                <span>Enrolled:</span>
                <span className="font-medium">
                  {course.enrolled.toLocaleString()} students
                </span>
              </div>
              <div className="flex justify-between text-sm">
                <span>Rating:</span>
                <span className="font-medium">{course.rating} / 5</span>
              </div>
            </div>
            <Button className="w-full">Enroll Now</Button>
          </CardContent>
        </Card>
      </div>

      <div className="flex items-center gap-4">
        <Avatar className="h-12 w-12">
          <AvatarImage src="/avatars/instructor.png" alt={course.instructor} />
          <AvatarFallback>{course.instructor[0]}</AvatarFallback>
        </Avatar>
        <div>
          <p className="font-medium">{course.instructor}</p>
          <p className="text-sm text-muted-foreground">Course Instructor</p>
        </div>
      </div>

      <Tabs defaultValue="overview" className="space-y-4">
        <TabsList>
          <TabsTrigger value="overview">Overview</TabsTrigger>
          <TabsTrigger value="syllabus">Syllabus</TabsTrigger>
          <TabsTrigger value="requirements">Requirements</TabsTrigger>
        </TabsList>

        <TabsContent value="overview" className="space-y-4">
          <Card>
            <CardHeader>
              <CardTitle>What You Will Learn</CardTitle>
            </CardHeader>
            <CardContent>
              <ul className="grid gap-3 md:grid-cols-2">
                {course.whatYouWillLearn.map((item, index) => (
                  <li key={index} className="flex items-center gap-2">
                    <svg
                      className="h-5 w-5 text-green-500"
                      fill="none"
                      stroke="currentColor"
                      viewBox="0 0 24 24"
                    >
                      <path
                        strokeLinecap="round"
                        strokeLinejoin="round"
                        strokeWidth={2}
                        d="M5 13l4 4L19 7"
                      />
                    </svg>
                    <span>{item}</span>
                  </li>
                ))}
              </ul>
            </CardContent>
          </Card>
        </TabsContent>

        <TabsContent value="syllabus" className="space-y-4">
          <Card>
            <CardHeader>
              <CardTitle>Course Content</CardTitle>
              <CardDescription>
                {course.syllabus.length} sections • {course.duration}
              </CardDescription>
            </CardHeader>
            <CardContent className="space-y-6">
              {course.syllabus.map((section, index) => (
                <div key={index}>
                  <h3 className="font-semibold">{section.title}</h3>
                  <ul className="mt-2 space-y-2">
                    {section.lessons.map((lesson, lessonIndex) => (
                      <li
                        key={lessonIndex}
                        className="flex items-center gap-2 text-sm text-muted-foreground"
                      >
                        <svg
                          className="h-4 w-4"
                          fill="none"
                          stroke="currentColor"
                          viewBox="0 0 24 24"
                        >
                          <path
                            strokeLinecap="round"
                            strokeLinejoin="round"
                            strokeWidth={2}
                            d="M14.752 11.168l-3.197-2.132A1 1 0 0010 9.87v4.263a1 1 0 001.555.832l3.197-2.132a1 1 0 000-1.664z"
                          />
                          <path
                            strokeLinecap="round"
                            strokeLinejoin="round"
                            strokeWidth={2}
                            d="M21 12a9 9 0 11-18 0 9 9 0 0118 0z"
                          />
                        </svg>
                        {lesson}
                      </li>
                    ))}
                  </ul>
                </div>
              ))}
            </CardContent>
          </Card>
        </TabsContent>

        <TabsContent value="requirements" className="space-y-4">
          <Card>
            <CardHeader>
              <CardTitle>Course Requirements</CardTitle>
            </CardHeader>
            <CardContent>
              <ul className="list-disc space-y-2 pl-4">
                {course.requirements.map((requirement, index) => (
                  <li key={index} className="text-muted-foreground">
                    {requirement}
                  </li>
                ))}
              </ul>
            </CardContent>
          </Card>
        </TabsContent>
      </Tabs>
    </div>
  );
}
