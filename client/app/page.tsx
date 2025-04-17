import Link from "next/link";
import { Button } from "@/components/ui/button";
import { Card, CardContent } from "@/components/ui/card";
import { ArrowRight, BookOpen, Users, BarChart } from "lucide-react";

export default function Home() {
  return (
    <div className="flex flex-col min-h-screen">
      {/* Hero Section */}
      <section className="pt-24 pb-12 px-4 sm:px-6 lg:px-8 bg-gradient-to-br from-primary/5 via-primary/10 to-primary/5">
        <div className="max-w-7xl mx-auto">
          <div className="text-center space-y-8 py-12">
            <h1 className="text-4xl md:text-6xl font-bold tracking-tight">
              Unlock Your Potential with
              <span className="text-primary"> Expert-Led</span> Learning
            </h1>
            <p className="text-xl text-gray-600 max-w-2xl mx-auto">
              Access high-quality courses, expert instructors, and a supportive
              learning community to achieve your goals.
            </p>
            <div className="flex justify-center gap-4">
              <Button size="lg" asChild>
                <Link href="/courses">Explore Courses</Link>
              </Button>
              <Button size="lg" variant="outline" asChild>
                <Link href="/about">Learn More</Link>
              </Button>
            </div>
          </div>
        </div>
      </section>

      {/* Features Section */}
      <section className="py-16 px-4 sm:px-6 lg:px-8">
        <div className="max-w-7xl mx-auto">
          <h2 className="text-3xl font-bold text-center mb-12">
            Why Choose Us
          </h2>
          <div className="grid md:grid-cols-3 gap-8">
            {features.map((feature) => (
              <Card key={feature.title}>
                <CardContent className="p-6">
                  <feature.icon className="h-12 w-12 text-primary mb-4" />
                  <h3 className="text-xl font-semibold mb-2">
                    {feature.title}
                  </h3>
                  <p className="text-gray-600">{feature.description}</p>
                </CardContent>
              </Card>
            ))}
          </div>
        </div>
      </section>

      {/* Featured Courses Section */}
      <section className="py-16 px-4 sm:px-6 lg:px-8 bg-gray-50">
        <div className="max-w-7xl mx-auto">
          <div className="flex justify-between items-center mb-12">
            <h2 className="text-3xl font-bold">Featured Courses</h2>
            <Button variant="ghost" className="flex items-center gap-2" asChild>
              <Link href="/courses">
                View All <ArrowRight className="h-4 w-4" />
              </Link>
            </Button>
          </div>
          <div className="grid md:grid-cols-3 gap-8">
            {featuredCourses.map((course) => (
              <Card key={course.title} className="overflow-hidden">
                <div className="aspect-video relative bg-gray-100">
                  {/* Replace with actual image */}
                  <div className="absolute inset-0 bg-gradient-to-br from-primary/30 to-primary/10" />
                </div>
                <CardContent className="p-6">
                  <div className="flex items-center gap-2 text-sm text-gray-600 mb-2">
                    <BookOpen className="h-4 w-4" />
                    <span>{course.lessons} lessons</span>
                    <span>•</span>
                    <span>{course.duration}</span>
                  </div>
                  <h3 className="text-xl font-semibold mb-2">{course.title}</h3>
                  <p className="text-gray-600 mb-4">{course.description}</p>
                  <Button className="w-full" asChild>
                    <Link href={`/courses/${course.id}`}>Learn More</Link>
                  </Button>
                </CardContent>
              </Card>
            ))}
          </div>
        </div>
      </section>

      {/* CTA Section */}
      <section className="py-16 px-4 sm:px-6 lg:px-8">
        <div className="max-w-7xl mx-auto text-center">
          <h2 className="text-3xl font-bold mb-4">Ready to Start Learning?</h2>
          <p className="text-xl text-gray-600 mb-8 max-w-2xl mx-auto">
            Join thousands of students who are already learning and growing with
            us.
          </p>
          <Button size="lg" asChild>
            <Link href="/register">Get Started Today</Link>
          </Button>
        </div>
      </section>
    </div>
  );
}

const features = [
  {
    title: "Expert Instructors",
    description:
      "Learn from industry professionals with years of experience in their fields.",
    icon: Users,
  },
  {
    title: "Quality Content",
    description:
      "Access carefully curated courses designed to provide practical, real-world skills.",
    icon: BookOpen,
  },
  {
    title: "Track Progress",
    description:
      "Monitor your learning journey with detailed progress tracking and analytics.",
    icon: BarChart,
  },
];

const featuredCourses = [
  {
    id: 1,
    title: "Web Development Fundamentals",
    description:
      "Learn the basics of web development with HTML, CSS, and JavaScript.",
    lessons: 24,
    duration: "12 hours",
  },
  {
    id: 2,
    title: "Data Science Essentials",
    description: "Master the fundamentals of data science and analysis.",
    lessons: 32,
    duration: "16 hours",
  },
  {
    id: 3,
    title: "Digital Marketing Strategy",
    description:
      "Develop effective digital marketing strategies for business growth.",
    lessons: 18,
    duration: "9 hours",
  },
];
