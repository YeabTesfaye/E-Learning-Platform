import Link from "next/link";
import Image from "next/image";
import { Card, CardContent, CardFooter } from "@/components/ui/card";
import { RegisterForm } from "@/components/features/auth/register-form";

export default function RegisterPage() {
  return (
    <div className="grid h-[92vh] overflow-hidden lg:grid-cols-2 lg:gap-0">
      {/* Left side - Testimonial */}
      <div className="relative hidden lg:flex mx-4">
        {/* Background Image */}
        <div className="absolute inset-0 rounded-2xl overflow-hidden">
          <Image
            src="/register-bg.png"
            alt="Online learning"
            fill
            sizes="50vw"
            quality={100}
            priority
            className="object-cover object-center"
            style={{ position: "absolute" }}
          />
        </div>
        {/* Gradient Overlay */}
        <div className="absolute inset-0 bg-gradient-to-br from-primary/60 via-primary/50 to-primary/40 backdrop-blur-[2px] rounded-2xl" />

        <div className="relative z-20 flex w-full flex-col justify-between p-12">
          {/* Logo and brand */}
          <div>
            <Link
              href="/"
              className="flex items-center text-lg font-bold text-white hover:opacity-90 transition-opacity"
            >
              EduLearn
            </Link>
          </div>

          {/* Testimonial content */}
          <div className="space-y-6">
            <blockquote className="space-y-4">
              <p className="text-2xl font-medium text-white">
                &quot;Joining EduLearn was the best decision for my career. The
                structured learning path and hands-on projects helped me land my
                dream job.&quot;
              </p>
              <footer className="text-sm text-white/90">
                <p className="font-semibold">Alex Chen</p>
                <p>Data Scientist at AI Solutions</p>
              </footer>
            </blockquote>
          </div>

          {/* Stats */}
          <div className="grid grid-cols-2 gap-4 text-white/90">
            <div>
              <p className="text-3xl font-bold">500+</p>
              <p className="text-sm">Expert Instructors</p>
            </div>
            <div>
              <p className="text-3xl font-bold">1M+</p>
              <p className="text-sm">Active Students</p>
            </div>
          </div>
        </div>
      </div>

      {/* Right side - Register form */}
      <div className="flex items-center justify-center p-8">
        <div className="mx-auto w-full max-w-sm space-y-6">
          <div className="space-y-2 text-center">
            <h1 className="text-3xl font-bold">Create an account</h1>
            <p className="text-gray-500 dark:text-gray-400">
              Start your learning journey today
            </p>
          </div>
          <Card>
            <CardContent className="pt-6">
              <RegisterForm />
            </CardContent>
            <CardFooter className="flex flex-col space-y-4 border-t pt-6">
              <div className="text-sm text-muted-foreground text-center">
                Already have an account?{" "}
                <Link
                  href="/login"
                  className="text-primary underline-offset-4 hover:underline font-medium"
                >
                  Sign in
                </Link>
              </div>
            </CardFooter>
          </Card>
        </div>
      </div>
    </div>
  );
}
