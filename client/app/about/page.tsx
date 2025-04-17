import { Metadata } from "next";
import { Button } from "@/components/ui/button";
import {
  Card,
  CardContent,
  CardDescription,
  CardHeader,
  CardTitle,
} from "@/components/ui/card";

export const metadata: Metadata = {
  title: "About | EduLearn",
  description: "Learn more about EduLearn and our mission",
};

export default function AboutPage() {
  return (
    <div className="flex-1 space-y-8 p-8 pt-6">
      <div className="flex items-center justify-between">
        <h2 className="text-3xl font-bold tracking-tight">About EduLearn</h2>
      </div>

      <div className="prose prose-slate max-w-none">
        <p className="text-xl text-muted-foreground">
          EduLearn is a modern e-learning platform dedicated to providing
          high-quality education accessible to everyone, everywhere.
        </p>
      </div>

      <div className="grid gap-6 md:grid-cols-2 lg:grid-cols-3">
        <Card>
          <CardHeader>
            <CardTitle>Our Mission</CardTitle>
          </CardHeader>
          <CardContent>
            <p className="text-muted-foreground">
              To democratize education by providing accessible, high-quality
              learning experiences to learners worldwide, empowering them to
              achieve their goals and unlock their full potential.
            </p>
          </CardContent>
        </Card>

        <Card>
          <CardHeader>
            <CardTitle>Our Vision</CardTitle>
          </CardHeader>
          <CardContent>
            <p className="text-muted-foreground">
              To create a world where quality education is accessible to
              everyone, breaking down barriers and fostering a global community
              of lifelong learners.
            </p>
          </CardContent>
        </Card>

        <Card>
          <CardHeader>
            <CardTitle>Our Values</CardTitle>
          </CardHeader>
          <CardContent>
            <ul className="list-disc list-inside space-y-2 text-muted-foreground">
              <li>Excellence in Education</li>
              <li>Innovation in Learning</li>
              <li>Inclusivity and Accessibility</li>
              <li>Student Success</li>
            </ul>
          </CardContent>
        </Card>
      </div>

      <Card>
        <CardHeader>
          <CardTitle>Why Choose EduLearn?</CardTitle>
          <CardDescription>Discover what makes us different</CardDescription>
        </CardHeader>
        <CardContent className="grid gap-6 md:grid-cols-2 lg:grid-cols-3">
          <div>
            <h3 className="text-lg font-semibold mb-2">Expert Instructors</h3>
            <p className="text-muted-foreground">
              Learn from industry professionals and experienced educators who
              are passionate about sharing their knowledge.
            </p>
          </div>
          <div>
            <h3 className="text-lg font-semibold mb-2">Flexible Learning</h3>
            <p className="text-muted-foreground">
              Study at your own pace with our flexible course schedules and
              on-demand content.
            </p>
          </div>
          <div>
            <h3 className="text-lg font-semibold mb-2">Interactive Content</h3>
            <p className="text-muted-foreground">
              Engage with dynamic course materials, hands-on projects, and
              real-world applications.
            </p>
          </div>
          <div>
            <h3 className="text-lg font-semibold mb-2">Community Support</h3>
            <p className="text-muted-foreground">
              Join a vibrant community of learners and get support when you need
              it.
            </p>
          </div>
          <div>
            <h3 className="text-lg font-semibold mb-2">Career Growth</h3>
            <p className="text-muted-foreground">
              Gain practical skills and certifications that help advance your
              career.
            </p>
          </div>
          <div>
            <h3 className="text-lg font-semibold mb-2">Affordable Pricing</h3>
            <p className="text-muted-foreground">
              Access quality education at competitive prices with flexible
              payment options.
            </p>
          </div>
        </CardContent>
      </Card>

      <div className="bg-muted rounded-lg p-8 text-center">
        <h2 className="text-2xl font-bold mb-4">Ready to Start Learning?</h2>
        <p className="text-muted-foreground mb-6">
          Join thousands of learners already learning on EduLearn
        </p>
        <Button size="lg" asChild>
          <a href="/courses">Browse Courses</a>
        </Button>
      </div>
    </div>
  );
}
