import { Metadata } from "next";
import { Button } from "@/components/ui/button";
import {
  Card,
  CardContent,
  CardDescription,
  CardHeader,
  CardTitle,
} from "@/components/ui/card";
import { Input } from "@/components/ui/input";
import { Label } from "@/components/ui/label";
import { Mail, MapPin, Phone } from "lucide-react";

export const metadata: Metadata = {
  title: "Contact | EduLearn",
  description: "Get in touch with our team",
};

export default function ContactPage() {
  return (
    <div className="flex-1 space-y-8 p-8 pt-6">
      <div className="flex items-center justify-between">
        <h2 className="text-3xl font-bold tracking-tight">Contact Us</h2>
      </div>

      <div className="grid gap-8 md:grid-cols-2">
        <Card>
          <CardHeader>
            <CardTitle>Send us a Message</CardTitle>
            <CardDescription>
              Fill out the form below and we&apos;ll get back to you as soon as
              possible
            </CardDescription>
          </CardHeader>
          <CardContent>
            <form className="space-y-4">
              <div className="grid gap-2">
                <Label htmlFor="name">Name</Label>
                <Input id="name" placeholder="Your name" />
              </div>
              <div className="grid gap-2">
                <Label htmlFor="email">Email</Label>
                <Input id="email" type="email" placeholder="Your email" />
              </div>
              <div className="grid gap-2">
                <Label htmlFor="subject">Subject</Label>
                <Input id="subject" placeholder="Message subject" />
              </div>
              <div className="grid gap-2">
                <Label htmlFor="message">Message</Label>
                <textarea
                  id="message"
                  className="min-h-[150px] w-full rounded-md border border-input bg-background px-3 py-2 text-sm"
                  placeholder="Your message"
                />
              </div>
              <Button className="w-full">Send Message</Button>
            </form>
          </CardContent>
        </Card>

        <div className="space-y-8">
          <Card>
            <CardHeader>
              <CardTitle>Contact Information</CardTitle>
              <CardDescription>
                Here are the ways you can reach us
              </CardDescription>
            </CardHeader>
            <CardContent className="space-y-4">
              <div className="flex items-start space-x-4">
                <Mail className="h-5 w-5 mt-1 text-muted-foreground" />
                <div>
                  <h3 className="font-semibold">Email</h3>
                  <p className="text-sm text-muted-foreground">
                    support@edulearn.com
                  </p>
                  <p className="text-sm text-muted-foreground">
                    info@edulearn.com
                  </p>
                </div>
              </div>
              <div className="flex items-start space-x-4">
                <Phone className="h-5 w-5 mt-1 text-muted-foreground" />
                <div>
                  <h3 className="font-semibold">Phone</h3>
                  <p className="text-sm text-muted-foreground">
                    +1 (555) 123-4567
                  </p>
                  <p className="text-sm text-muted-foreground">
                    Mon-Fri: 9:00 AM - 6:00 PM EST
                  </p>
                </div>
              </div>
              <div className="flex items-start space-x-4">
                <MapPin className="h-5 w-5 mt-1 text-muted-foreground" />
                <div>
                  <h3 className="font-semibold">Address</h3>
                  <p className="text-sm text-muted-foreground">
                    123 Learning Street
                    <br />
                    Suite 100
                    <br />
                    New York, NY 10001
                    <br />
                    United States
                  </p>
                </div>
              </div>
            </CardContent>
          </Card>

          <Card>
            <CardHeader>
              <CardTitle>FAQ</CardTitle>
              <CardDescription>
                Common questions about our platform
              </CardDescription>
            </CardHeader>
            <CardContent className="space-y-4">
              <div>
                <h3 className="font-semibold">How do I enroll in a course?</h3>
                <p className="text-sm text-muted-foreground">
                  Simply browse our courses, select the one you&apos;re
                  interested in, and click the &quot;Enroll Now&quot; button.
                </p>
              </div>
              <div>
                <h3 className="font-semibold">
                  What payment methods do you accept?
                </h3>
                <p className="text-sm text-muted-foreground">
                  We accept all major credit cards, PayPal, and bank transfers.
                </p>
              </div>
              <div>
                <h3 className="font-semibold">Can I get a refund?</h3>
                <p className="text-sm text-muted-foreground">
                  Yes, we offer a 30-day money-back guarantee for all our
                  courses.
                </p>
              </div>
            </CardContent>
          </Card>
        </div>
      </div>
    </div>
  );
}
