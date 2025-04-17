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
import { Tabs, TabsContent, TabsList, TabsTrigger } from "@/components/ui/tabs";
import { Avatar, AvatarFallback, AvatarImage } from "@/components/ui/avatar";
import { Badge } from "@/components/ui/badge";

export const metadata: Metadata = {
  title: "Profile | EduLearn",
  description: "Manage your profile and preferences",
};

export default function ProfilePage() {
  return (
    <div className="flex-1 space-y-4 p-8 pt-6">
      <div className="flex items-center justify-between space-y-2">
        <h2 className="text-3xl font-bold tracking-tight">Profile</h2>
      </div>

      <Tabs defaultValue="general" className="space-y-4">
        <TabsList>
          <TabsTrigger value="general">General</TabsTrigger>
          <TabsTrigger value="preferences">Preferences</TabsTrigger>
          <TabsTrigger value="achievements">Achievements</TabsTrigger>
        </TabsList>

        <TabsContent value="general" className="space-y-4">
          <Card>
            <CardHeader>
              <CardTitle>Profile Information</CardTitle>
              <CardDescription>
                Update your personal information and profile picture
              </CardDescription>
            </CardHeader>
            <CardContent className="space-y-6">
              <div className="flex items-center space-x-4">
                <Avatar className="h-24 w-24">
                  <AvatarImage src="/avatars/user.png" alt="User" />
                  <AvatarFallback>UN</AvatarFallback>
                </Avatar>
                <Button>Change Avatar</Button>
              </div>
              <div className="grid gap-4">
                <div className="grid gap-2">
                  <Label htmlFor="name">Full Name</Label>
                  <Input
                    id="name"
                    placeholder="Enter your name"
                    defaultValue="User Name"
                  />
                </div>
                <div className="grid gap-2">
                  <Label htmlFor="email">Email</Label>
                  <Input
                    id="email"
                    placeholder="Enter your email"
                    type="email"
                    defaultValue="user@example.com"
                  />
                </div>
                <div className="grid gap-2">
                  <Label htmlFor="bio">Bio</Label>
                  <textarea
                    id="bio"
                    className="min-h-[100px] w-full rounded-md border border-input bg-background px-3 py-2 text-sm"
                    placeholder="Write a short bio..."
                  />
                </div>
              </div>
            </CardContent>
          </Card>
        </TabsContent>

        <TabsContent value="preferences" className="space-y-4">
          <Card>
            <CardHeader>
              <CardTitle>Learning Preferences</CardTitle>
              <CardDescription>
                Customize your learning experience
              </CardDescription>
            </CardHeader>
            <CardContent className="space-y-4">
              {/* Add preference settings here */}
            </CardContent>
          </Card>
        </TabsContent>

        <TabsContent value="achievements" className="space-y-4">
          <Card>
            <CardHeader>
              <CardTitle>Your Achievements</CardTitle>
              <CardDescription>
                Certificates and badges you&apos;ve earned
              </CardDescription>
            </CardHeader>
            <CardContent>
              <div className="grid gap-4 md:grid-cols-2 lg:grid-cols-3">
                {[1, 2, 3].map((i) => (
                  <Card key={i}>
                    <CardHeader>
                      <Badge className="w-fit">Certificate</Badge>
                      <CardTitle className="text-lg">
                        Web Development Fundamentals
                      </CardTitle>
                      <CardDescription>
                        Completed on March 15, 2024
                      </CardDescription>
                    </CardHeader>
                    <CardContent>
                      <Button variant="outline" className="w-full">
                        View Certificate
                      </Button>
                    </CardContent>
                  </Card>
                ))}
              </div>
            </CardContent>
          </Card>
        </TabsContent>
      </Tabs>

      <div className="flex justify-end space-x-4">
        <Button variant="outline">Cancel</Button>
        <Button>Save Changes</Button>
      </div>
    </div>
  );
}
