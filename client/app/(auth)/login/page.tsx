import Link from "next/link";
import Image from "next/image";
import { Card, CardContent, CardFooter } from "@/components/ui/card";
import { LoginForm } from "@/components/features/auth/login-form";

export default function LoginPage() {
  return (
    <div className="grid h-[92vh] overflow-hidden lg:grid-cols-2 lg:gap-0">
      {/* Left side - Testimonial */}
      <div className="relative hidden lg:flex mx-4">
        {/* Background Image */}
        <div className="absolute inset-0 rounded-2xl overflow-hidden">
          <Image
            src="/auth-bg.png"
            alt="Students learning"
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
                &quot;This platform has completely transformed how I approach
                learning. The courses are comprehensive and the instructors are
                top-notch.&quot;
              </p>
              <footer className="text-sm text-white/90">
                <p className="font-semibold">Sofia Davis</p>
                <p>Software Engineer at TechCorp</p>
              </footer>
            </blockquote>
          </div>

          {/* Additional info */}
          <div className="flex items-center space-x-4 text-white/90">
            <div className="text-sm">
              Trusted by over 20,000 students worldwide
            </div>
          </div>
        </div>
      </div>

      {/* Right side - Login form */}
      <div className="flex items-center justify-center p-8">
        <div className="mx-auto w-full max-w-sm space-y-6">
          <div className="space-y-2 text-center">
            <h1 className="text-3xl font-bold">Welcome back</h1>
            <p className="text-gray-500 dark:text-gray-400">
              Enter your credentials to access your account
            </p>
          </div>
          <Card>
            <CardContent className="pt-6">
              <LoginForm />
            </CardContent>
            <CardFooter className="flex flex-col space-y-4 border-t pt-6">
              <div className="text-sm text-muted-foreground text-center">
                Don&apos;t have an account?{" "}
                <Link
                  href="/register"
                  className="text-primary underline-offset-4 hover:underline font-medium"
                >
                  Sign up
                </Link>
              </div>
            </CardFooter>
          </Card>
        </div>
      </div>
    </div>
  );
}
