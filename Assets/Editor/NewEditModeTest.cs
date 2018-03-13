using UnityEngine;
using UnityEditor;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

public class NewEditModeTest {

	[Test]
	public void NewEditModeTestSimplePasses() {
        // Use the Assert class to test conditions.
        Assert.Pass();
	}

    [Test]
    public void JosephusTestWorks()
    {
        Josephus joe = GameObject.FindObjectOfType<Josephus>();
        joe.output.text = "something";
        Assert.That(joe.output.text.Equals("something"), "Test works");
    }

    [Test]
    public void JosephusOnlyAcceptsNumericInput()
    {
        Josephus joe = GameObject.FindObjectOfType<Josephus>();
        joe.output.text = "hi";
        joe.JosephusAlgorithm("a");
        Assert.That(joe.output.text.Equals(""));
    }

    [Test]
    public void JosephusOnlyAcceptsPositiveInput()
    {
        Josephus joe = GameObject.FindObjectOfType<Josephus>();
        joe.JosephusAlgorithm("-1");
        Assert.That(joe.output.text.Equals(""));
    }

    [Test]
    public void JosephusI1O1()
    {
        Josephus joe = GameObject.FindObjectOfType<Josephus>();
        joe.JosephusAlgorithm("1");
        Assert.That(joe.output.text.Equals("1"));
    }

    [Test]
    public void JosephusI2O1()
    {
        Josephus joe = GameObject.FindObjectOfType<Josephus>();
        joe.JosephusAlgorithm("2");
        Assert.AreEqual(joe.output.text, "1");
    }

    [Test]
    public void JosephusI5O3()
    {
        Josephus joe = GameObject.FindObjectOfType<Josephus>();
        joe.JosephusAlgorithm("5");
        Assert.AreEqual(joe.output.text, "3", "value was: "+joe.output.text);
    }

    // A UnityTest behaves like a coroutine in PlayMode
    // and allows you to yield null to skip a frame in EditMode
    [UnityTest]
	public IEnumerator NewEditModeTestWithEnumeratorPasses() {
		// Use the Assert class to test conditions.
		// yield to skip a frame
		yield return null;
	}
}
